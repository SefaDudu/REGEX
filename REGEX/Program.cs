// See https://aka.ms/new-console-template for more information
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

var desc = "<h3>Genel Bilgi</h3><p>Adobe Acrobat Reader 22.003.20282 (ve öncesi), 22.003.20281 (ve öncesi) ve 20.005.30418 (ve öncesi) sürümlerinin etkilendiği, rastgele kod yürütülmesine sebebiyet veren güvenlik açığı tespit edilmiştir.</p><h3>Etki</h3><p>Mevcut güvenlik açıklıkları nedeniyle siber saldırganların zafiyetleri kullanarak saldırılarını gerçekleştirmeleri ihtimal dâhilindedir.İlgili zafiyetin CVE kodu,</p><p>CVE-2023-21608</p><h3>Çözüm</h3><p>Ulusal Siber Olaylara Müdahale Merkezi (USOM) kullanıcı ve sistem yöneticilerine dokümanını gözden geçirmelerini ve gerekli güncellemeleri yapılmasını tavsiye etmektedir.</p><h3>Kaynaklar</h3><p><a href=\"https://nvd.nist.gov/vuln/detail/CVE-2023-21608\">https://nvd.nist.gov/vuln/detail/CVE-2023-21608</a></p><p><a href=\"https://helpx.adobe.com/security/products/acrobat/apsb23-01.html\">https://helpx.adobe.com/security/products/acrobat/apsb23-01.html</a></p>";

var result = Regex.Replace(desc, @"<[^>]*>", String.Empty);

Console.WriteLine(result);