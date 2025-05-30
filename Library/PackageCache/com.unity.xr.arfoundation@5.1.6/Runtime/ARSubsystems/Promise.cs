namespace UnityEngine.XR.ARSubsystems
{
    /// <summary>
    /// A Promise is used for operations that retrieve data asynchronously. Use this object
    /// to determine the status of the operation (that is, whether it has completed), and
    /// the resulting data.
    /// </summary>
    /// <remarks>
    /// Since <see cref="Promise{T}"/> derives from <c>CustomYieldInstruction</c>,
    /// you can <c>yield return</c> on a Promise in a coroutine. If you prefer not
    /// to use the Promise as a coroutine, you can manually check <see cref="Promise{T}.keepWaiting"/>
    /// to determine if the operation has completed. Once the operation is complete, you can get the
    /// resulting value from <see cref="Promise{T}.result"/>.
    /// </remarks>
    /// <example>
    /// <para>Example usage in a coroutine:</para>
    /// <code>
    /// IEnumerator MyCoroutine()
    /// {
    ///     var promise = GetDataAsync();
    ///     yield return promise;
    ///     Debug.LogFormat("Operation complete. Result = {0}", promise.result);
    /// }
    /// </code>
    /// </example>
    /// <typeparam name="T">The type of information the asynchronous operation retrieves.</typeparam>
    public abstract class Promise<T> : CustomYieldInstruction
    {
        bool m_Complete;

        /// <summary>
        /// Will return <see langword="true"/> as long as the operation has not yet completed.
        /// </summary>
        public override bool keepWaiting
        {
            get
            {
                OnKeepWaiting();
                return !m_Complete;
            }
        }

        /// <summary>
        /// The result of the asynchronous operation. Not valid until <see cref="keepWaiting"/> returns <see langword="false"/>.
        /// </summary>
        public T result { get; private set; }

        /// <summary>
        /// Creates a resolved promise (that is, a promise that is already complete).
        /// </summary>
        /// <param name="result">The result of the operation.</param>
        /// <returns>A completed <see cref="Promise{T}"/>.</returns>
        public static Promise<T> CreateResolvedPromise(T result)
        {
            return new ImmediatePromise(result);
        }

        /// <summary>
        /// The creator of the <see cref="Promise{T}"/> should call this when the asynchronous operation completes.
        /// </summary>
        /// <param name="result">The result of the asynchronous operation.</param>
        protected void Resolve(T result)
        {
            this.result = result;
            m_Complete = true;
        }

        /// <summary>
        /// Invoked whenever <see cref="keepWaiting"/> is queried. Implement this to perform per-frame updates.
        /// </summary>
        protected abstract void OnKeepWaiting();

        class ImmediatePromise : Promise<T>
        {
            protected override void OnKeepWaiting() { }

            public ImmediatePromise(T immediateResult)
            {
                Resolve(immediateResult);
            }
        }
    }
}
