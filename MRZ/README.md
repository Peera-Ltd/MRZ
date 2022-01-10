# MRZ

MRZ is a simple, fast, well tested parser of MRZ codes commonly found in official documents, such as passports and visas.

This project supports MRZ of 3 types:

# TD1:
3 lines of 30 characters.
![alt text](https://www.doubango.org/SDKs/mrz/docs/_images/td1_image.jpg)

# TD2:
2 lines of 36 characters.

![alt text](https://www.doubango.org/SDKs/mrz/docs/_images/td2_image.jpg)

# TD3:
2 lines of 44 characters.

![alt text](https://www.doubango.org/SDKs/mrz/docs/_images/td3_image.jpg)

MRVA and MRVB are also supported but as there is no functionality to extract optional data, they are treated the same as TD2 and TD3 respectively.

# Using the package

```C#
using MRZ;
using MRZ.Models;

namespace Test;
    
class Sample {
    private void Test() {
        // Ensure that the MRZ you pass has no whitespace.
        var mrz = "I<UTOD231458907<<<<<<<<<<<<<<<" +
                  "7408122F1204159UTO<<<<<<<<<<<6" +
                  "ERIKSSON<<ANNA<MARIA<<<<<<<<<<";
        
        // Parse() can throw an UnsupportedMRZException if the MRZ is invalid.
        MRZModel model;
        try 
        {          
            model = Parser.Parse(mrz);
        }
        catch(Exception e) 
        {
            Console.WriteLine($"Failed to parse MRZ: {mrz}. Exception: {e}");
        }
        
        Console.WriteLine($"Name is is {model.FirstName} {model.LastName}");
    }
}
```
