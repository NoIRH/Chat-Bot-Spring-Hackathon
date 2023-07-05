using GameEngine;
using System.ComponentModel;

enum States
{
	[Description("Ваше число сильно больше")]
    IsWarm,
    [Description("Ваше число несколько больше")]
    IsHot,
    [Description("Вы очень рядом")]
    IsVeryHot,
    [Description("Почти дотянули")]
    IsChilly,
    [Description("Ваше число заметно меньше")]
    IsCold,
    [Description("Ваше число сильно меньше")]
    IsVeryCold,
    [Description("Ура! Вы угадали!_)")]
    IsRight,
    [Description("Вы предположили что-то очень странное")]
    IsWrong
}
public class HotOrCold : MiniGame
{
	public (int start, int end) Range { get; set; } = (0, 100);
	public int CountSteps { get; set; }
	
    private int Value;
    public HotOrCold()
	{
        Name = "Горячо холодно)!";
        GameDescription = "Это игра горячо холодно. Загадывается число — вы должны его угадать. Вам будут даваться подсказки ";
    }
	public void Start(int start = 0, int end = 100)
	{
		IsWorked = true;
		Range = (start, end);
		Value = new Random().Next(Range.start, Range.end);
    }
	public string Guess(int variant)
	{
		var state  = GetState(variant);
        CountSteps++;
        return GetEnumDescription(state);
    }
	private States GetState(int variant)
	{
		var rangeMain = Range.end - Range.start; 
        var range = Math.Abs(variant - Value);
        if (variant == Value)
        {
            IsWorked = false;
            return States.IsRight;
        }
        if(variant < Value)
        {
            if (range <= rangeMain / 16) return States.IsChilly;
            if (range <= rangeMain / 8) return States.IsCold;
            return States.IsVeryCold;
        }
        else
        {
            if (range <= rangeMain / 16) return States.IsVeryHot;
            if (range <= rangeMain / 8) return States.IsHot;
            return States.IsWarm;
        }
	}
    private string GetEnumDescription(Enum value)
    {
        var fieldInfo = value.GetType().GetField(value.ToString());
        var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
        return attributes.Length > 0 ? attributes[0].Description : value.ToString();
    }

}
