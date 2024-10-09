# Cryptography
Multiple algorithm cryptography text component for .Net

## Example
```c#
string hash = ParsElecom.Cryptography.GUID.RandomHex(80)
```
```c#
using ParsElecom.Cryptography;

string pass = Encrypt.GenerateHash("test", Encrypt.EncodingType.HEX, Encrypt.Algorithm.MD5)
```
