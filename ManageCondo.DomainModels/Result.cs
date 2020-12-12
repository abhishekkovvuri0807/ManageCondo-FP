namespace ManageCondo.DomainModels
{
    public class Result<T>
    {
        public bool isSuccess { get; set; }
        public string successMessage { get; set; }
        public string errorMessage { get; set; }
        public T data { get; set; }

        public Result(bool isSuccess, string message, T data) : this(isSuccess, message)
        {   
            this.data = data;
        }

        public Result(bool isSuccess, string messages)
        {
            this.isSuccess = isSuccess;
            if (this.isSuccess)
            {
                successMessage = messages;
            }
            else
            {
                errorMessage = messages;
            }
        }

        public static Result<T> Success(T resultData, string successMessage)
        {
            Result<T> result = new Result<T>(true, successMessage, resultData);
            return result;
        }

        public static Result<T> Fail(string errorMessage)
        {
            Result<T> result = new Result<T>(false, errorMessage);
            return result;
        }


    }
}
