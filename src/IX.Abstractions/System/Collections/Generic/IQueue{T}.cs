// <copyright file="IQueue{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using DiagCA = System.Diagnostics.CodeAnalysis;

namespace IX.System.Collections.Generic
{
    /// <summary>
    ///     A contract for a queue.
    /// </summary>
    /// <typeparam name="T">The type of elements in the queue.</typeparam>
    /// <seealso cref="IEnumerable{T}" />
    /// <seealso cref="ICollection" />
    /// <seealso cref="IReadOnlyCollection{T}" />
    [PublicAPI]
    [DiagCA.SuppressMessage(
        "ReSharper",
        "PossibleInterfaceMemberAmbiguity",
        Justification = "Member ambiguity is unavoidable when implementing ICollection")]
    public interface IQueue<T> : ICollection, IReadOnlyCollection<T>
    {
        /// <summary>
        ///     Gets a value indicating whether this queue is empty.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this queue is empty; otherwise, <c>false</c>.
        /// </value>
        bool IsEmpty { get; }

        /// <summary>
        ///     Clears the queue of all elements.
        /// </summary>
        void Clear();

        /// <summary>
        ///     Verifies whether or not an item is contained in the queue.
        /// </summary>
        /// <param name="item">The item to verify.</param>
        /// <returns><see langword="true" /> if the item is queued, <see langword="false" /> otherwise.</returns>
        bool Contains(
#if NETSTANDARD2_1
            [DiagCA.AllowNull]
#endif
            [CanBeNull]
            T item);

        /// <summary>
        ///     De-queues an item and removes it from the queue.
        /// </summary>
        /// <returns>The item that has been de-queued.</returns>
#if NETSTANDARD2_1
        [return: DiagCA.MaybeNull]
#endif
        [CanBeNull]
        T Dequeue();

        /// <summary>
        ///     Attempts to de-queue an item and to remove it from queue.
        /// </summary>
        /// <param name="item">The item that has been de-queued, default if unsuccessful.</param>
        /// <returns>
        ///     <see langword="true" /> if an item is de-queued successfully, <see langword="false" /> otherwise, or if the
        ///     queue is empty.
        /// </returns>
        bool TryDequeue(
#if NETSTANDARD2_1
            [DiagCA.MaybeNull]
#endif
            [CanBeNull]
            out T item);

        /// <summary>
        /// Attempts to peek at the current queue and return the item that is next in line to be dequeued.
        /// </summary>
        /// <param name="item">The item, or default if unsuccessful.</param>
        /// <returns><see langword="true" /> if an item is found, <see langword="false"/> otherwise, or if the queue is empty.</returns>
        bool TryPeek(
#if NETSTANDARD2_1
            [DiagCA.MaybeNull]
#endif
            [CanBeNull]
            out T item);

        /// <summary>
        ///     Queues an item, adding it to the queue.
        /// </summary>
        /// <param name="item">The item to enqueue.</param>
        void Enqueue(
#if NETSTANDARD2_1
            [DiagCA.AllowNull]
#endif
            [CanBeNull]
            T item);

        /// <summary>
        ///     Queues a range of elements, adding them to the queue.
        /// </summary>
        /// <param name="items">The item range to push.</param>
        void EnqueueRange(
#if NETSTANDARD2_1
            [DiagCA.DisallowNull]
#endif
            [NotNull]
            T[] items);

        /// <summary>
        ///     Queues a range of elements, adding them to the queue.
        /// </summary>
        /// <param name="items">The item range to enqueue.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="count">The number of items to enqueue.</param>
        void EnqueueRange(
#if NETSTANDARD2_1
            [DiagCA.DisallowNull]
#endif
            [NotNull]
            T[] items,
            int startIndex,
            int count);

        /// <summary>
        ///     Peeks at the topmost element in the queue, without removing it.
        /// </summary>
        /// <returns>The item peeked at, if any.</returns>
#if NETSTANDARD2_1
        [return: DiagCA.MaybeNull]
#endif
        [CanBeNull]
        T Peek();

        /// <summary>
        ///     Copies all elements of the queue into a new array.
        /// </summary>
        /// <returns>The created array with all element of the queue.</returns>
        [NotNull]
#if NETSTANDARD2_1
        [return: DiagCA.NotNull]
#endif
        T[] ToArray();

        /// <summary>
        ///     Trims the excess free space from within the queue, reducing the capacity to the actual number of elements.
        /// </summary>
        void TrimExcess();
    }
}