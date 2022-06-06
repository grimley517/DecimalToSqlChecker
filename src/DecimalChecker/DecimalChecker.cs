namespace DecimalChecker;
public class DecimalChecker
{
public int Scale { get; set; }  
public int Precision { get; set; }  

public DecimalChecker(int scale, int precision){
    Scale = scale;
    Precision = precision;
}
public bool IsCompatible(decimal number){
    throw new NotImplementedException();
}
}
