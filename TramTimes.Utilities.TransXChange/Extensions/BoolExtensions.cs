namespace TramTimes.Utilities.TransXChange.Extensions;

public static class BoolExtensions
{
    public static int ToInt(this bool? baseBool)
    {
        return !baseBool.HasValue ? 0 : baseBool.Value ? 1 : 0;
    }
}