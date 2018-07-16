using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EPiServer;
using EPiServer.Core;
using EPiServer.Core.Internal;
using EPiServer.Security;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using MyLibrary.Core.Extensions;

namespace EpiServer.Extensions
{
	/// <summary>
	///     Extension methods for <see cref="IContent"/>
	/// </summary>
	public static class ContentExtensions
	{
		private static IContentRepository _repo;		

		/// <summary>
		///     Filters content for the current visitor/user according to publish status and page access
		/// </summary>
		/// <typeparam name="TContentType">Type of content items</typeparam>
		/// <param name="content">The items to check access for</param>
		/// <returns>A filtered list containing content items that the current user has access to</returns>
		public static IEnumerable<TContentType> FilterForVisitor<TContentType>(this IEnumerable<TContentType> content)
			where TContentType : class, IContent
		{
			if (_repo == null)
			{
				_repo = ServiceLocator.Current.GetInstance<IContentRepository>();
			}
			
			return content.Where(c => c != null && c.QueryAccess() != AccessLevel.NoAccess && c.QueryAccess() != AccessLevel.Undefined && _repo.Get<IContent>(c.ContentLink).IsPublished());
		}

		/// <summary>
		///     Loads a <see cref="IContent" /> instance from a <see cref="ContentReference" /> optionally from a certain language
		///     and filtered for visitor access
		/// </summary>
		/// <typeparam name="TContentType">Type of content to load</typeparam>
		/// <param name="contentLink"><see cref="ContentReference" /> of the content to load</param>
		/// <param name="languageSelector">The <see cref="ILanguageSelector" /> to use.</param>
		/// <param name="filterForVisitor">If the content should be filtered by visitor access rights.</param>
		/// <param name="contentLoader">
		///     Optional <see cref="IContentLoader" />, uses ApplicationServices.CurrentServiceLocator to resolve if null
		/// </param>
		/// <returns>A <see cref="IContent" /> instance, or null if not found</returns>
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

		public static List<GetChildrenReferenceResult> GetChildContentReferences<T>(this ContentReference contentRef)
			where T : class, IContent
		{
			ContentProvider provider = DataFactory.Instance.ProviderMap.GetProvider(contentRef);

			List<GetChildrenReferenceResult> childContentReferences = provider.GetChildrenReferences<T>(contentRef, null, -1, -1).ToList();
			childContentReferences.AddRange(provider.GetChildrenReferences<ContentFolder>(contentRef, null, -1, -1));
			return childContentReferences.Distinct().ToList();
		}

		/// <summary>
		///     Gets all children of a certain type
		/// </summary>
		/// <typeparam name="TContent"></typeparam>
		/// <returns></returns>
		public static IEnumerable<TContent> GetChildren<TContent>(this ContentData content, LanguageSelector languageSelector = null)
			where TContent : class, IContent
		{
			if (content == null)
			{
				return null;
			}

			return GetChildren<TContent>((content as IContent)?.ContentLink, null, languageSelector);
		}

		/// <summary>
		///     gets all children of a certain type
		/// </summary>
		/// <typeparam name="TContent"></typeparam>
		/// <param name="contentRef"></param>
		/// <param name="filterExpression">A Lambda to filter out the pages that do not comply</param>
		/// <param name="languageSelector">Language</param>
		/// <returns></returns>
		public static IEnumerable<TContent> GetChildren<TContent>(this ContentReference contentRef, Expression<Func<TContent, bool>> filterExpression = null, LanguageSelector languageSelector = null)
			where TContent : class, IContent
		{
			if (ContentReference.IsNullOrEmpty(contentRef))
			{
				return null;
			}

			IContentRepository contentRepo = ServiceLocator.Current.GetInstance<IContentRepository>();
			if (languageSelector == null)
			{
				languageSelector = new NullLanguageSelector();
			}

			if (filterExpression == null)
			{
				return contentRepo.GetChildren<TContent>(contentRef, languageSelector).FilterForVisitor();
			}

			var filterFunc = filterExpression.Compile();
			return contentRepo.GetChildren<TContent>(contentRef, languageSelector).FilterForVisitor().Where(page => filterFunc(page));
		}

		public static IEnumerable<T> GetContentItems<T>(this ContentArea contentArea)
			where T : ContentData
		{
			if (contentArea.HasContent())
			{
				return contentArea.FilteredItems.Select(item => item.GetContent() as T).RemoveNull();
			}

			return Enumerable.Empty<T>();
		}

		/// <summary>
		///     Gets ALL descendents of a certain content type
		/// </summary>
		/// <typeparam name="TContent"></typeparam>
		/// <param name="contentRef"></param>
		/// <param name="filterExpression">A Lambda to filter out the pages that do not comply</param>
		/// <param name="languageSelector">Language</param>
		/// <returns></returns>
		[Obsolete]
		public static IEnumerable<TContent> GetDescendents<TContent>(this ContentReference contentRef, Expression<Func<TContent, bool>> filterExpression = null, LanguageSelector languageSelector = null)
			where TContent : class, IContent
		{
			if (ContentReference.IsNullOrEmpty(contentRef))
			{
				yield break;
			}

			var filterFunc = filterExpression == null ? null : filterExpression.Compile();
			if (languageSelector == null)
			{
				languageSelector = new NullLanguageSelector();
			}

			foreach (var child in contentRef.GetChildren<IContent>(null, languageSelector))
			{
				if (child is TContent && (filterFunc == null || filterFunc(child as TContent)))
				{
					yield return child as TContent;
				}

				foreach (var grandChild in child.ContentLink.GetDescendents(filterExpression, languageSelector))
				{
					yield return grandChild;
				}
			}
		}

		public static Url GetUrl(this ContentReference contentLink)
		{
			return ServiceLocator.Current.GetInstance<UrlResolver>().GetUrl(contentLink);
		}

		public static bool IsNullOrEmpty(this ContentArea contentArea)
		{
			return contentArea?.FilteredItems == null || !contentArea.FilteredItems.Any();
		}

		public static bool HasContent(this ContentArea contentArea)
		{
			return contentArea?.FilteredItems != null && contentArea.FilteredItems.Any();
		}

		private static bool IsPublished(this IContent content)
		{
			IVersionable obj = content as IVersionable;
			if (obj == null) return false;
			
			if (obj.IsPendingPublish ||
			    obj.Status != VersionStatus.Published ||
			    obj.StartPublish > DateTime.Now ||
			    obj.StopPublish < DateTime.Now)
			{
				return false;
			}

			return true;
		}

		/// <summary>
		///     Checks if a role has access to this piece of content
		/// </summary>
		/// <param name="content">IContent</param>
		/// <param name="roles">Array of Roles, example: new[] { "Everyone" }</param>
		/// <param name="accessLevel">Epi Security Access Level, example: AccessLevel.Read</param>
		/// <returns></returns>
		public static bool RoleHasAccess(this IContent content, string[] roles, AccessLevel accessLevel)
		{
			var securedContent = content as ISecurable;
			var descriptor = securedContent.GetSecurityDescriptor();
			var principal = PrincipalInfo.AnonymousPrincipal;
			return descriptor.HasAccess(principal, accessLevel);
		}
	}
}
