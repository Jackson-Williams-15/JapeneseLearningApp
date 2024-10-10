namespace JapaneseLearning.Helpers;


public class TatoebaResponse
{
    public List<TatoebaResult> results { get; set; }
}

public class TatoebaResult
{
    public string text { get; set; }
    public List<TatoebaTranslation> translations { get; set; }
}

public class TatoebaTranslation
{
    public string text { get; set; }
}
