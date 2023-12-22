namespace XynokConvention.APIs
{
    public interface IValidator
     {
         bool IsValid();
     }
    
    public interface IValidator<in T>
    {
        bool IsValid(T other);
    }
 }