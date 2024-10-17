// Matthew Riddell SOA CA1 - D00245674
// API Service abstract class

namespace SOA_CA1.Services
{
    public abstract class ApiService<T>
    {
        protected abstract string ApiUrl { get; }
        protected abstract string ApiKey { get; }


    }
}
