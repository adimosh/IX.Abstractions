// <copyright file="IStack{T}.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using DiagCA = System.Diagnostics.CodeAnalysis;

namespace IX.System.Collections.Generic
{
    /// <summary>
    ///     A contract for a stack.
    /// </summary>
    /// <typeparam name="T">The type of elements in the stack.</typeparam>
    /// <seealso cref="IEnumerable{T}" />
    /// <seealso cref="ICollection" />
    /// <seealso cref="IReadOnlyCollection{T}" />
    [PublicAPI]
    [DiagCA.SuppressMessage(
        "ReSharper",
        "PossibleInterfaceMemberAmbiguity",
        Justification = "Member ambiguity is unavoidable when implementing ICollection")]
    public interface IStack<T> : ICollection, IReadOnlyCollection<T>
    {
        /// <summary>
        ///     Gets a value indicating whether this stack is empty.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this stack is empty; otherwise, <c>false</c>.
        /// </value>
        bool IsEmpty { get; }

        /// <summary>
        ///     Clears the observable stack.
        /// </summary>
        void Clear();

        /// <summary>
        ///     Checks whether or not a certain item is in the stack.
        /// </summary>
        /// <param name="item">The item to check for.</param>
        /// <returns><see langword="true" /> if the item was found, <see langword="false" /> otherwise.</returns>
        bool Contains(
#if NETSTANDARD2_1
            [DiagCA.AllowNull]
#endif
            [CanBeNull]
            T item);

        /// <summary>
        ///     Peeks in the stack to view the topmost item, without removing it.
        /// </summary>
        /// <returns>The topmost element in the stack, if any.</returns>
#if NETSTANDARD2_1
        [return: DiagCA.MaybeNull]
#endif
        [CanBeNull]
        T Peek();

        /// <summary>
        ///     Pops the topmost element from the stack, removing it.
        /// </summary>
        /// <returns>The topmost element in the stack, if any.</returns>
#if NETSTANDARD2_1
        [return: DiagCA.MaybeNull]
#endif
        [CanBeNull]
        T Pop();

        /// <summary>
        ///     Attempts to pop the topmost item from the stack, and remove it if successful.
        /// </summary>
        /// <param name="item">The topmost element in the stack, default if unsuccessful.</param>
        /// <returns>
        ///     <see langword="true" /> if an item is popped successfully, <see langword="false" /> otherwise, or if the
        ///     stack is empty.
        /// </returns>
        bool TryPop(
#if NETSTANDARD2_1
            [DiagCA.MaybeNull]
#endif
            [CanBeNull]
            out T item);

        /// <summary>
        ///     Attempts to peek at the topmost item from the stack, without removing it.
        /// </summary>
        /// <param name="item">The topmost element in the stack, default if unsuccessful.</param>
        /// <returns>
        ///     <see langword="true" /> if an item is peeked at successfully, <see langword="false" /> otherwise, or if the
        ///     stack is empty.
        /// </returns>
        bool TryPeek(
#if NETSTANDARD2_1
            [DiagCA.MaybeNull]
#endif
            [CanBeNull]
            out T item);

        /// <summary>
        ///     Pushes an element to the top of the stack.
        /// </summary>
        /// <param name="item">The item to push.</param>
        void Push(
#if NETSTANDARD2_1
            [DiagCA.AllowNull]
#endif
            [CanBeNull]
            T item);

        /// <summary>
        ///     Pushes a range of elements to the top of the stack.
        /// </summary>
        /// <param name="items">The item range to push.</param>
        void PushRange(
#if NETSTANDARD2_1
            [DiagCA.DisallowNull]
#endif
            [NotNull]
            T[] items);

        /// <summary>
        /// Pushes a range of elements to the top of the stack.
        /// </summary>
        /// <param name="items">The item range to push.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="count">The number of items to push.</param>
        void PushRange(
#if NETSTANDARD2_1
            [DiagCA.DisallowNull]
#endif
            [NotNull]
            T[] items,
            int startIndex,
            int count);

        /// <summary>
        ///     Copies all elements of the stack to a new array.
        /// </summary>
        /// <returns>An array containing all items in the stack.</returns>
        [NotNull]
#if NETSTANDARD2_1
        [return: DiagCA.NotNull]
#endif
        T[] ToArray();

        /// <summary>
        ///     Sets the capacity to the actual number of elements in the stack if that number is less than 90 percent of current
        ///     capacity.
        /// </summary>
        void TrimExcess();
    }
}