# ASP.NET C# için Regex (Regular Expressions) Notları – 1 

Regular Expressions, yani  düzenli İfadeler, string bir değişkenin ya da bir metnin, verilen kalıpla eşleşip eşleşmediğini kontrol etmek için kullanılan bir modeldir. Aynı zamanda, bu ifadeler sayesinde, bir metnin içinde, belirli desenlere uyan detaylı aramalar yapabilir ya da belli kurallara uyan alt metinler elde edilebilir.

Bu makalede öncelikle RegularExpressions kütüphanesine göz atıp, c# da kullanımına bakacağız. Daha sonra RegularExpressions diline ait özel karakterlere ve son olarak da sık kullanılan ifade gruplarına bakacağız.

# RegularExpression Kütüphanesi

C# içerisinde Regex kullanabilmek için  System.Text.RegularExpression kütüphanesini eklememiz gerekmektedir.

#using System.Text.RegularExpressions; 
Bu kütüphanede Regex sınıfı içinde kullanılabilen pek çok faydalı methot vardır. örnek olarak:

#Escape : Verilen string ifadenin içine bulunan özel karakterlerin başına “escape” yani “-\” karakteri ekler. Örnek olarak “\n” stringini “\\n” stringine çevirir.

UnEscape : Verilen string ifadenin içine bulunan “escape -\” karakterlerini kaldırır. Mesela iki string ifadenin kıyaslanması sırasında, öncelikle stringde bulunan “\” karakterlerinden sadece escape olarak kullanılanlarını temizlemek isteyebiliriz. bu gibi durumlarda çok faydalıdır.

#Equals : İki string ifadeyi kıyaslayarak aynı olup olmadığı bilgisini true/false olarak döner. Örnek olarak:

string = "123abc";
System.Text.RegularExpressions.Regex.Equals(text1, "123abc");

Sonuç: true


#IsMatch : Bir stringin içinde, diğer bir string ya da bir ifadenin bulunup bulunmadığı bilgisini true/false olarak döner. kullanılan string ya da regex değerleri, başlangıç index değeri vs. göre 5 farklı kullanım şekli vardır. Örnek olarak:

string = "123abc";
System.Text.RegularExpressions.Regex.Equals(text1, "123");

Sonuç: true


#Match :Bir stringin içinde, diğer bir stringi, ya da bir ifadeyi bulup, ilk bulduğu değeri “Match” sınıfı olarak döndürür. Match sınıfı için tıklayınız. 6 farklı kullanım tipi vardır. Bunlar sayesinde istenilen düzenli ifade ayarlanabilir, veya metnin içinde arama yapılacak başlangıç noktası ya da ne kadar uzunlukta arama yapılacağı belirlenebilir.

Örnek kullanımı: verilen string değer içinde, tanımlanan regex ifadesine göre arama yapıp bulduğu ilk eşleşmeyi döndürür.

string input = "Regular Expressions Kullanımı";
      Regex regex = new Regex(@"g*r");
      Match m = regex.Match(input);

Sonuc: m.value="gular"


#Matches : Bir stringin içinde, diğer bir stringi ya da bir ifadeyi bulup, bulduğu tüm değerleri “MatchCollection” olarak döndürür. MatchCollection Sınıfı için tıklayınız. 5 farklı kullanımı vardır.

#Örnek kullanımı:

string input = "Regular Expressions Kullanımı";
      Regex regex = new Regex(@"+n");
      MatchCollection matches = Regex.Matches(input,regex);

Sonuc: matches[0] Index=16, Value="on"
       matches[1] Index=24, Value="an"


#Replace : Bir stringin içinde, diğer bir stringi ya da bir ifadeyi bulup , istenilen bir string ile ya da diğer regex ifade ile değiştirir. Kullanım amacına göre pek çok farklı değişken alan 12 tipi vardır.

Örnek olarak:

 string  metin = "Bu    metnin  içinde     " +     
                 "çok    fazla   boşluk   var";      
 string pattern = "\\s+";      
 string result = Regex.Replace(metin, pattern, " "); 

 sonuç  metin = "Bu metnin içinde çok fazla boşluk var"



#Split : Bir stringin içinde, belirtilen string ya da bir regex ifadeye göre parçalayıp, string bir diziye atar. 6 farklı kullanım şekli vardır.
Örnek olarak: tarih bilgisi tutan bir metni, gün-ay-yıl olarak parçalara ayırma işlemi.

 string tarih= @"20/04/2020";   
 string pattern = @"(-)|(/)";
 string[] result = Regex.Split(tarih, pattern)

  sonuc result[0]= "20";
        result[1]= "04";
        result[2]= "2020";
#ASP.NET MVC İçin Regular Expression Kullanımı
Mvc içerisinde çok kolay bir şelikde regex ifadeler kullanabiliriz. Bunun ilk yöntemi, yukarıdaki örneklerde de verildiği gibi, kodlama kısmında, regex kütüphanesi eklenerek, string değişkenler üzerinden kullanımıdır.

#Nesne içinde Regular Expression Kullanımı
Regular expressionun diğer bir kullanım şekli ise, bir nesne oluşturulurken, içinde bulunan değişkenin başına, o değişkene ait kullanım kurallarını yazmaktır. Bu şekilde bir doğrulama yöntemi elde etmiş oluyoruz.

Örnek olarak: Kisi sınıfında bulunan isim ve soyisim değişkeni için, geçerli bir format girildiğinden emin olmak için, sadece harflerin kullanılabileceği bir kural ekliyoruz.

public class Kisi
{
    [RegularExpression(@"^[a-zA-Z]*$"]
    public string Isim{ get; set;}

    [RegularExpression(@"^[a-zA-Z]*$"]
    public string SoyIsim{ get; set;}
}

#CSHTML ile, Razor Dosyalarında Regular Expression Kullanımı
Çoğu zaman, sayfamızda veri girişi esnasında, girilen verilerin istediğimiz formata uygunluğunu kontrol etmek isteriz. Özellikle email girişi, para formatları, telefon numarası girişi gibi işlemlerde, hatanın hemen yakalanması ve uyarı verilmesi bizi pek çok iş maliyetinden kurtarabilir. Bu gibi durumlarda, cshtml kullanarak, razor dosyalarında regular expression ifadeleri kullanılabilir. Örnek olarak:

@using (Html.BeginForm())
        {
            @Html.LabelFor(model => model.Isim, htmlAttributes: new { @class = "control-label col-md-2" })
            @Html.TextBoxFor(model => model.Isim, new { @class = "form-control", pattern = @"^[a-zA-Z]*$"  })
            @Html.ValidationMessageFor(model => model.Isim, "", new { @class = "text-danger" })
            <input type="submit" value="Submit" />
        }

#Javascript İçinde Regular Expression Kullanımı
Form içinde, özel bazı filtreleme, kontrol ya da veri doğruluğu işlemlerinin kontrolü için sık sık javascript işlemlerine baş vururuz. Bu işlemler için regex ifadeler de kullanılabilir. Örnek olarak girilen telefon numarasının istenilen formatta olup olmadığını kontrol ettirelim:

<script>
var pattern = /(?:\d{3}|\(\d{3}\))([-\/\.])\d{3}\1\d{4}/;
function testInfo(phoneInput) {
  var OK = pattern.ismatch(phoneInput.value);
  if (!OK) {
    alert(phoneInput.value + ' geçerli telefon numarası formatında değildir'); 
  } 
</script>
