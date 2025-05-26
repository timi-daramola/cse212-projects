public class FeatureCollection
{
    public List<Feature> Features { get; set; } // Represents the "features" array in the JSON
}

public class Feature
{
    public Properties Properties { get; set; } // Represents the "properties" object in each feature
}

public class Properties
{
    public string Place { get; set; } // Represents the "place" attribute
    public double? Mag { get; set; }  // Represents the "mag" attribute (nullable in case it's missing)
}