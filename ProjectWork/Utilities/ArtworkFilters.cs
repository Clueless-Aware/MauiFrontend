namespace ProjectWork.Utilities;

public static class ArtworkFilters
{
    public static readonly List<string> UniqueForms = new()
    {
        "painting", "architecture", "ceramics", "sculpture", "graphics",
        "stained-glass", "metalwork", "illumination", "furniture",
        "mosaic", "others", "tapestry", "glassware"
    };

    public static readonly List<string> UniqueTypes = new()
    {
        "mythological", "historical", "genre", "portrait",
        "landscape", "religious",
        "other", "interior", "still-life", "study"
    };

    public static readonly List<string> UniqueTimeFrames = new()
    {
        "1601-1650", "1851-1900", "1451-1500", "1501-1550", "1751-1800", "1551-1600",
        "1701-1750", "1801-1850", "1651-1700", "1301-1350", "1401-1450", "1351-1400",
        "1251-1300", "1151-1200", "1101-1150", "0501-0550", "1001-1050", "1201-1250",
        "0551-0600", "0951-1000", "1051-1100", "0651-0700", "0801-0850", "0751-0800",
        "0851-0900", "0601-0650", "0901-0950", "0201-0250", "0301-0350", "0351-0400",
        "0451-0500", "0401-0450", "0701-0750", "0251-0300"
    };
}