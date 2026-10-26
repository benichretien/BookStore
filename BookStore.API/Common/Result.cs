using System.Diagnostics.CodeAnalysis;

namespace BookStore.API.Common
{
    public class Result
    {
        protected Result(Error? error) => Error = error;

        public Error? Error { get; }

        [MemberNotNullWhen(false, nameof(Error))]
        public bool IsSuccess => Error is null;

        public static Result Success() => new(null);

        public static implicit operator Result(Error error) => new(error);
    }

    public sealed class Result<TValue> : Result
    {
        private readonly TValue? value;

        private Result(TValue value) : base(null) => this.value = value;

        private Result(Error error) : base(error) { }

        public TValue Value => IsSuccess
            ? value!
            : throw new InvalidOperationException("Cannot access the value of a failed result.");

        public static implicit operator Result<TValue>(TValue value) => new(value);

        public static implicit operator Result<TValue>(Error error) => new(error);
    }
}
