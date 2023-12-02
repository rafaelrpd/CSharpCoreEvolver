using System.Reflection;

namespace CoreService.Anonimyzer
{
    public class AnonymizerService
    {
        public TEntity AnonymizeEntity<TEntity>(TEntity entity)
        {
            return AnonymizeProperties(entity);
        }

        public decimal AnonymizeEntity(decimal entity)
        {
            return AnonymizeDecimal(entity);
        }

        public string AnonymizeEntity(string entity)
        {
            return AnonymizeString(entity);
        }

        public DateTime AnonymizeEntity(DateTime entity)
        {
            return AnonymizeDateTime(entity);
        }

        private TEntity AnonymizeProperties<TEntity>(TEntity entity)
        {
            var stringProperties = entity.GetType().GetProperties().Where(p => p.CanRead && p.CanWrite && p.PropertyType == typeof(string));
            var decimalProperties = entity.GetType().GetProperties().Where(p => p.CanRead && p.CanWrite && (p.PropertyType == typeof(decimal) || p.PropertyType == typeof(decimal?)));
            var dateTimeProperties = entity.GetType().GetProperties().Where(p => p.CanRead && p.CanWrite && (p.PropertyType == typeof(DateTime) || p.PropertyType == typeof(DateTime?)));

            foreach (var property in stringProperties)
            {
                var value = property.GetValue(entity) as string;
                if (!string.IsNullOrWhiteSpace(value))
                {
                    property.SetValue(entity, AnonymizeString(value));
                }
            }

            foreach (var property in decimalProperties)
            {
                var rawValue = property.GetValue(entity);
                if (rawValue != null)
                {
                    decimal value = (decimal)rawValue;
                    property.SetValue(entity, AnonymizeDecimal(value));
                }
            }

            foreach (var property in dateTimeProperties)
            {
                var rawValue = property.GetValue(entity);
                if (rawValue != null)
                {
                    DateTime value = (DateTime)rawValue;
                    property.SetValue(entity, AnonymizeDateTime(value));
                }
            }

            return entity;
        }

        private decimal AnonymizeDecimal(decimal value)
        {
            return 0M;
        }

        private string AnonymizeString(string value)
        {
            return new string('X', value.Length);
        }

        private DateTime AnonymizeDateTime(DateTime value)
        {
            return new DateTime(2000, 1, 1);
        }
    }
}