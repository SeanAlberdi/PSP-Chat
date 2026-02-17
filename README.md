# 💬 TCP Txat Sistema (C# Sockets)

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Windows Forms](https://img.shields.io/badge/Windows%20Forms-purple?style=for-the-badge)

Proiektu hau **denbora errealeko txat-sistema** bat da, C# eta .NET Framework erabiliz garatua. Arkitektura **Bezero-Zerbitzaria (Client-Server)** da eta **TCP Sockets** teknologian oinarritzen da komunikazioa kudeatzeko.

Helburu nagusia sare bidezko komunikazioa, harien kudeaketa (multithreading) eta segurtasun oinarriak (hashing) praktikatzea da.

---

## 🚀 Ezaugarriak

Proiektuak bi zati nagusi ditu:

### 🖥️ Zerbitzaria (Console App)
* **TCP Listener:** Edozein IP helbidetatik datozen konexioak onartzen ditu 8888 portuan.
* **Multithreading:** Erabiltzaile bakoitza hari (Thread) independente batean kudeatzen da, sistema blokeatu gabe.
* **Broadcasting:** Jasotako mezuak konektatutako erabiltzaile guztiei birbidaltzen dizkie.
* **Jarraipena:** Kontsolan erakusten du nork konektatzen eta deskonektatzen den.

### 💻 Bezeroa (Windows Forms)
* **Login Interfazea:** Erabiltzaile eta pasahitz bidezko sarbidea.
* **Segurtasuna:** Pasahitzak **SHA256** erabiliz zifratzen dira (Hashing) zerbitzarira edo APIra bidali aurretik.
* **Chat Interfazea:** Mezuak idatzi eta beste erabiltzaileenak denbora errealean ikusteko aukera.
* **Konexio Kudeaketa:** Zerbitzariarekin konexioa egiaztatzen du eta errorea ematen du zerbitzaria itzalita badago.

---

## 🛠️ Teknologia eta Arkitektura

* **Lengoaia:** C#
* **Framework:** .NET (Windows Forms & Console)
* **Protokoloa:** TCP/IP (`System.Net.Sockets`)
* **Segurtasuna:** `System.Security.Cryptography` (SHA256)
* **Asinkronia:** `System.Threading` & `Tasks`

---

## 📋 Nola Erabili (Instalazioa)

Proiektu hau Visual Studio-rekin irekitzeko prestatuta dago.

1.  **Klonatu biltegia:**
    ```bash
    git clone [https://github.com/zure-erabiltzailea/Chat-Sockets-CSharp.git](https://github.com/zure-erabiltzailea/Chat-Sockets-CSharp.git)
    ```
2.  **Ireki Soluzioa:**
    Ireki `ChatCompleto.sln` fitxategia Visual Studio-n.
3.  **Abiarazi Proiektuak:**
    * Oso garrantzitsua da **bi proiektuak batera** abiaraztea.
    * Egin klik eskuineko botoiarekin Soluzioan -> *Properties* -> *Multiple startup projects*.
    * Jarri `ServidorChat` eta `ClienteChat` **"Start"** moduan.

### ⚠️ Garrantzitsua
Zerbitzaria (`ServidorChat`) beti abiarazi behar da Bezeroa (`ClienteChat`) baino lehen. Bestela, bezeroak ezin izango du konexioa ezarri.

---

## 🔐 Login Informazioa (Demo)

Momentuz, sistema lokalean probatzeko erabiltzaile hauek daude konfiguratuta (API integrazioaren zain):

| Erabiltzailea | Pasahitza |
| :--- | :--- |
| **Edozein izen** | `1234` |

> Pasahitza `1234` bada ere, barnean SHA256 hash bihurtzen da segurtasuna bermatzeko.

Edozein zalantza edo iradokizun baduzu, jarri nirekin harremanetan!

---
