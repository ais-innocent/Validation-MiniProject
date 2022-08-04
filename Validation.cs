using System.Text.RegularExpressions;

string ConvertPersianDigitsToEnglishDigits(string number) {
    return Enumerable.Range(0, 10).Aggregate(number, (current, i) => current.Replace((char)('۰' + i), (char)('0' + i)));
}

bool CheckEmail(string email) {
	return new Regex(@"^[\w\-.]+@([\w-]+\.)+[\w-]{2,4}$").IsMatch(email);
}

bool CheckPhoneNumber(string phoneNumber) {
    phoneNumber = ConvertPersianDigitsToEnglishDigits(phoneNumber);
	return new Regex(@"^(\+98|0)?(9)(\d){9}$").IsMatch(phoneNumber);
}

bool CheckNationalCode(string nationalCode) {
    nationalCode = ConvertPersianDigitsToEnglishDigits(nationalCode);
    if (new Regex(@"^\d{10}$").IsMatch(nationalCode) == false)
        return false;
    var check = Convert.ToInt32(nationalCode[9].ToString());
    var sum = 0;
    for(int i = 0; i < 9; i++) {
        sum += Convert.ToInt32(nationalCode[i].ToString()) * (10 - i);
    }
    sum %= 11;
    return (sum < 2) ? check == sum : (check + sum) == 11;
}

Console.Write("Please enter your email: ");
var email = Console.ReadLine();
Console.WriteLine($"Your email is {(CheckEmail(email) ? "valid" : "invalid")}");

Console.Write("Please enter your phone number: ");
var phoneNumber = Console.ReadLine();
Console.WriteLine($"Your phone number is {(CheckPhoneNumber(phoneNumber) ? "valid" : "invalid")}");

Console.Write("Please enter your national code: ");
var nationalCode = Console.ReadLine();
Console.WriteLine($"Your national code is {(CheckNationalCode(nationalCode) ? "valid" : "invalid")}");

Console.ReadKey();
