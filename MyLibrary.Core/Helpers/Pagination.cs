using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Core
{
    /// <summary>
    /// Basic pagination content class
    /// </summary>
    public class ItemPagination
    {
        /// <summary>
        /// Constructor for ItemPagination
        /// </summary>
        public ItemPagination()
        {
            IsActive = false;
            PageNumber = 0;
        }
        /// <summary>
        /// Is the current page number the active page?
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Current page number
        /// </summary>
        public uint PageNumber { get; set; }
    }

    /// <summary>
    /// Pagination creation methods
    /// </summary>
    public class Pagination
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(Pagination));

        /// <summary>
        /// Create the pagination object to be displayed on the page
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="currentPage"></param>
        /// <param name="totalPages"></param>
        /// <param name="maxPagesToShow"></param>
        /// <returns></returns>
        public IEnumerable<T> SetPagination<T>(uint currentPage, uint totalPages, uint maxPagesToShow) where  T : ItemPagination
        {
            try
            {
                uint firstPage = 1;
                uint lastPage = 1;
                uint maxPages = totalPages <= maxPagesToShow ? totalPages : maxPagesToShow;
                uint halfPoint = (uint)Math.Floor((double)maxPages / 2);
                if (currentPage <= halfPoint)
                {
                    firstPage = 1;
                    lastPage = maxPages;
                }
                else if (currentPage >= (totalPages - halfPoint))
                {
                    firstPage = (totalPages - maxPages) + 1;
                    lastPage = totalPages;
                }
                else
                {
                    firstPage = currentPage - halfPoint;
                    lastPage = currentPage + halfPoint;
                }

                var resultSet = new List<T>();
                for (uint i = firstPage; i <= lastPage; i++)
                {
                    var item = new ItemPagination
                    {
                        IsActive = (i == currentPage),
                        PageNumber = i
                    };
                    resultSet.Add(item as T);
                }
                return resultSet;
            } catch
            {
                _logger.Error("There was an error creating the pagination sequence.");
            }
            return null;
        }
    }
}
