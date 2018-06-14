using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using EPiServer;
using EPiServer.Core;
using EPiServer.Core.Internal;
using EPiServer.Security;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using MyLibrary.Extensions;

namespace Episerver.Extensions
{
	public static class ContentExtensions
	{
		private static Func<IContent, bool> _visitorFilterer;
		private static IContentRepository _repo;

		/// <summary>
		/// returns true if the current user has access to the specified content
		/// </summary>
		public static Func<IContent, bool> VisitorFilterer
		{
			get { return _visitorFilterer ?? (content => content != null && EPiServer.Filters.FilterForVisitor.Filter(new[] { content }).Any()); }
			set { _visitorFilterer = value; }
		}

		/// <summary>
		/// Filters content for the current visitor/user according to publish status and page access
		/// </summary>
		/// <remarks>Uses the <see cref="VisitorFilterer"/>, to determine if a visitor have access or not</remarks>
		/// <typeparam name="TContentType">Type of content items</typeparam>
		/// <param name="content">The items to check access for</param>
		/// <returns>A filtered list containing content items that the current user has access to</returns>
		public static IEnumerable<TContentType> FilterForVisitor<TContentType>(this IEnumerable<TContentType> content)
			where TContentType : class, IContent
		{
			if (_repo == null)
				_repo = ServiceLocator.Current.GetInstance<IContentRepository>();

			//return content.Where(c => VisitorFilterer(c));
			return content.Where(c => c != null
				&& c.QueryAccess() != EPiServer.Security.AccessLevel.NoAccess
				&& c.QueryAccess() != EPiServer.Security.AccessLevel.Undefined
				&& _repo.Get<IContent>(c.ContentLink).CheckPublishedStatus(PagePublishedStatus.Published));
		}

		/// <summary>
		/// Checks if a role has access to this piece of content
		/// </summary>
		/// <param name="content">IContent</param>
		/// <param name="roles">Array of Roles, example: new[] { "Everyone" }</param>
		/// <param name="accessLevel">Epi Security Access Level, example: AccessLevel.Read</param>
		/// <returns></returns>
		public static Boolean RoleHasAccess(this IContent content, string[] roles, AccessLevel accessLevel)
		{
			var securedContent = content as ISecurable;
			var descriptor = securedContent.GetSecurityDescriptor();
			var principal = PrincipalInfo.AnonymousPrincipal;
			return descriptor.HasAccess(principal, accessLevel);
		}

		private static bool CheckPublishedStatus(this IContent content, PagePublishedStatus status)
		{
			IVersionable obj = content as IVersionable;
			if (obj == null)
				return false;

			if (status != PagePublishedStatus.Ignore)
			{
				if (obj.IsPendingPublish)
				{
					return false;
				}
				if (obj.Status != VersionStatus.Published)
				{
					return false;
				}
				if ((status >= PagePublishedStatus.PublishedIgnoreStopPublish) && (obj.StartPublish > DateTime.Now))//Context.Current.RequestTime))
				{
					return false;
				}
				if ((status >= PagePublishedStatus.Published) && (obj.StopPublish < DateTime.Now))//Context.Current.RequestTime))
				{
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// Loads a <see cref="IContent"/> instance from a <see cref="ContentReference"/> optionally from a certain language and filtered for visitor access
		/// </summary>
		/// <typeparam name="TContentType">Type of content to load</typeparam>
		/// <param name="contentLink"><see cref="ContentReference"/> of the content to load</param>
		/// <param name="languageSelector">The <see cref="ILanguageSelector"/> to use.</param>
		/// <param name="filterForVisitor">If the content should be filtered by visitor access rights.</param>
		/// <param name="contentLoader">Optional <see cref="IContentLoader"/>, uses <see cref="ApplicationServices.CurrentServiceLocator"/> to resolve if null</param>
		/// <returns>A <see cref="IContent"/> instance, or null if not found</returns>
		public static TContentType Get<TContentType>(this ContentReference contentLink, bool filterForVisitor = false, IContentLoader contentLoader = null, LanguageSelector languageSelector = null)
			where TContentType : class, IContent
		{
			if (ContentReference.IsNullOrEmpty(contentLink))
			{
				return null;
			}

			if (contentLoader == null)
			{
				contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
			}

			if (languageSelector == null)
			{
				languageSelector = new NullLanguageSelector();
			}

			//Logger.Default.Log(string.Format("Get: getting content of type '{3}' for reference '{0}' with language selector {1} using content loader '{2}'", contentLink, languageSelector, contentLoader.GetType().FullName, typeof(TContentType).FullName), LogType.Debug);

			try
			{
				var content = contentLoader.Get<TContentType>(contentLink, languageSelector);
				return filterForVisitor ? new[] { content }.FilterForVisitor().FirstOrDefault() : content;
			}
			catch (ContentNotFoundException)
			{
			}
			catch (TypeMismatchException)
			{
			}
			return null;
		}

		/// <summary>
		/// Gets all children of a certain type
		/// </summary>
		/// <typeparam name="TContent"></typeparam>
		/// <param name="page"></param>
		/// <returns></returns>
		public static IEnumerable<TContent> GetChildren<TContent>(this ContentData content, LanguageSelector languageSelector = null) where TContent : class, IContent
		{
			if (content == null)
				return null;
			return GetChildren<TContent>((content as IContent).ContentLink, null, languageSelector);
		}

		/// <summary>
		/// gets all children of a certain type
		/// </summary>
		/// <typeparam name="TContent"></typeparam>
		/// <param name="contentRef"></param>
		/// <param name="filterExpression">A Lambda to filter out the pages that do not comply</param>
		/// <returns></returns>
		public static IEnumerable<TContent> GetChildren<TContent>(this ContentReference contentRef, Expression<Func<TContent, bool>> filterExpression = null, LanguageSelector languageSelector = null) where TContent : class, IContent
		{
			if (ContentReference.IsNullOrEmpty(contentRef))
				return null;

			IContentRepository contentRepo = ServiceLocator.Current.GetInstance<IContentRepository>();
			if (languageSelector == null)
				languageSelector = new NullLanguageSelector();

			if (filterExpression == null)
				return contentRepo.GetChildren<TContent>(contentRef, languageSelector).FilterForVisitor();

			var filterFunc = filterExpression.Compile();
			return contentRepo.GetChildren<TContent>(contentRef, languageSelector).FilterForVisitor().Where(page => filterFunc(page));
		}

		/// <summary>
		/// Gets ALL descendents of a certain content type
		/// </summary>
		/// <typeparam name="TContent"></typeparam>
		/// <param name="contentRef"></param>
		/// <param name="filterExpression">A Lambda to filter out the pages that do not comply</param>
		/// <returns></returns>
		[Obsolete]
		public static IEnumerable<TContent> GetDescendents<TContent>(this ContentReference contentRef, Expression<Func<TContent, bool>> filterExpression = null, LanguageSelector languageSelector = null) where TContent : class, IContent
		{
			if (ContentReference.IsNullOrEmpty(contentRef))
				yield break;

			var filterFunc = filterExpression == null ? null : filterExpression.Compile();
			if (languageSelector == null)
				languageSelector = new NullLanguageSelector();

			foreach (var child in contentRef.GetChildren<IContent>(null, languageSelector))
			{
				if (child is TContent && (filterFunc == null || filterFunc(child as TContent)))
					yield return (child as TContent);
				foreach (var grandChild in child.ContentLink.GetDescendents<TContent>(filterExpression, languageSelector))
				{
					yield return grandChild;
				}
			}
		}

		public static List<GetChildrenReferenceResult> GetChildContentReferences<T>(this ContentReference contentRef) where T : class, IContent
		{
			ContentProvider provider = DataFactory.Instance.ProviderMap.GetProvider(contentRef);

			List<GetChildrenReferenceResult> childContentReferences = provider.GetChildrenReferences<T>(contentRef, null, -1, -1).ToList();
			childContentReferences.AddRange(provider.GetChildrenReferences<ContentFolder>(contentRef, null, -1, -1));
			return childContentReferences.Distinct().ToList();
		}

		public static Url GetUrl(this ContentReference contentLink)
		{
			return ServiceLocator.Current.GetInstance<UrlResolver>().GetUrl(contentLink);
		}

		public static bool IsNullOrEmpty(this ContentArea contentArea)
		{
			if (contentArea != null && contentArea.FilteredItems != null && contentArea.FilteredItems.Any())
				return false;
			else
				return true;
		}

		public static IEnumerable<TContentType> GetContentItems<TContentType>(this ContentArea contentArea) where TContentType : ContentData
		{
			if (!contentArea.IsNullOrEmpty())
			{
				return contentArea.FilteredItems.Select(item => item.GetContent() as TContentType).RemoveNull();
			}
			else
			{
				return Enumerable.Empty<TContentType>();
			}
		}
	}
}
