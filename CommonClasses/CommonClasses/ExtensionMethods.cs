using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace CommonClasses.CommonClasses
{

    public static class ExtensionMethods
    {

        /// <summary>
        ///               Filters a sequence of values based on a predicate.
        ///           </summary>
        /// <returns>
        ///               An <see cref="T:System.Collections.Generic.IEnumerable`1" /> that contains elements from the input sequence that satisfy the condition.
        ///           </returns>
        /// <param name="source">
        ///               An <see cref="T:System.Collections.Generic.IEnumerable`1" /> to filter.
        ///           </param>
        /// <param name="predicate">
        ///               A function to test each element for a condition.
        ///           </param>
        /// <typeparam name="TSource">
        ///               The type of the elements of <paramref name="source" />.
        ///           </typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="source" /> or <paramref name="predicate" /> is null.
        ///           </exception>
        public static ICollection<TSource> Where<TSource>(this ICollection<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                //throw Error.ArgumentNull("source");
                throw new ArgumentNullException("source");

            }

            if (predicate == null)
            {
                // throw Error.ArgumentNull("predicate");
                throw new ArgumentNullException("predicate");
            }



            //if (source is Enumerable.Iterator<TSource>)
            //{
            //    return ((Enumerable.Iterator<TSource>)source).Where(predicate);
            //}
            // ObservableCollection
            //System.Collections.ObjectModel.Collection
            ICollection<TSource> collection = new System.Collections.ObjectModel.Collection<TSource>();
            if (source is System.Collections.ObjectModel.Collection<TSource>)            //.Iterator<TSource>)
            {

                foreach (TSource ts in source)        //.Iterator<TSource>)source).Where(predicate);
                {
                    if (predicate(ts))
                        collection.Add(ts);

                }
            }

            //if (source is TSource[])
            //{
            //    return new Enumerable.WhereArrayIterator<TSource>((TSource[])source, predicate);
            //}
            //if (!(source is List<TSource>))
            //{
            //    return new Enumerable.WhereEnumerableIterator<TSource>(source, predicate);
            //}
            //return new Enumerable.WhereListIterator<TSource>((List<TSource>)source, predicate);
            return collection;
        }

        /// <summary>
        ///               Filters a sequence of values based on a predicate. Each element's index is used in the logic of the predicate function.
        ///           </summary>
        /// <returns>
        ///               An <see cref="T:System.Collections.Generic.IEnumerable`1" /> that contains elements from the input sequence that satisfy the condition.
        ///           </returns>
        /// <param name="source">
        ///               An <see cref="T:System.Collections.Generic.IEnumerable`1" /> to filter.
        ///           </param>
        /// <param name="predicate">
        ///               A function to test each source element for a condition; the second parameter of the function represents the index of the source element.
        ///           </param>
        /// <typeparam name="TSource">
        ///               The type of the elements of <paramref name="source" />.
        ///           </typeparam>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="source" /> or <paramref name="predicate" /> is null.
        ///           </exception>
        public static ICollection<TSource> Where<TSource>(this ICollection<TSource> source, Func<TSource, int, bool> predicate)
        {
            //if (source == null)
            //{
            //    throw Error.ArgumentNull("source");
            //}
            //if (predicate == null)
            //{
            //    throw Error.ArgumentNull("predicate");
            //}
            //return Enumerable.WhereIterator<TSource>(source, predicate);
            return null;
        }



    }   
}
