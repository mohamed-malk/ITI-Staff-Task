namespace Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string baseEntity, string childEntity) :
                    base($"this {baseEntity} doesn't have any {childEntity}")
        { }
        public NotFoundException(string entity): base($"The {entity} Not Found") 
        { }
    }
}
