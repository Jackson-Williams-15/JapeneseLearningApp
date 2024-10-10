namespace JapaneseLearning.Helpers;


public class JishoResponse
{
    public List<JishoData> data { get; set; }
}

public class JishoData
{
    public string slug { get; set; }
    public List<JishoJapanese> japanese { get; set; }
    public List<JishoSense> senses { get; set; }
}

public class JishoJapanese
{
    public string reading { get; set; }
}

public class JishoSense
{
    public List<string> english_definitions { get; set; }
}
