namespace SerializationReflectionOtus.Serializers;

public class CsvSerializer
{
    public static string Serialize<T>(T obj)
    {
        var type = typeof(T);
        var properties = type.GetProperties();
        var values = properties.Select(property => property.GetValue(obj));
        
        return string.Join(',', values);
    }

    public static T Deserialize<T>(string csv)
    {
        var type = typeof(T);
        var obj = (T)Activator.CreateInstance(typeof(T))!;
        var properties = type.GetProperties();
        var val = csv.Split(',');
        for (int i = 0; i < val.Length && i < properties.Length; i++)
        {
            var value = Convert.ChangeType(val[i], properties[i].PropertyType);
            properties[i].SetValue(obj, value);
        }

        return obj;
    }
}