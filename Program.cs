var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<int> numbersDrawn = new List<int>();



app.MapGet("/bingo/draw", () => drawNum());
app.MapGet("/bingo/view", () => viewNum());
app.MapGet("/bingo/check/{num}", (int num) => checkNum(num));
app.MapGet("/bingo/reset", () => resetNum());


string drawNum(){
    Random rnd = new Random();
    int randomNumber = rnd.Next(1,101);
    if (numbersDrawn.Count < 100){
        while (numbersDrawn.Contains(randomNumber)){
            randomNumber = rnd.Next(1,101);
        }
        numbersDrawn.Add(randomNumber);
        return $"The number {randomNumber.ToString()} was drawn";
    }
    else{
        return $"All the numbers have been drawn";
    }
}

System.Collections.Generic.List<int> viewNum(){
    foreach (var number in numbersDrawn)
    {
        System.Console.WriteLine(number);
    }
    return numbersDrawn;
}

string checkNum(int num){
    bool checkForMatch = false;
    foreach (var number in numbersDrawn) {
        if (number == num) {
            checkForMatch = true;
        }
    }
    if (checkForMatch == true){
        return $"The number {num.ToString()} has been drawn";
    }
    else {
        return $"The number {num.ToString()} has not been drawn";
    }
}

string resetNum(){
    numbersDrawn.Clear();
    return "All your numbers are belong to us!";
}

app.Run();
