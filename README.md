# Student-Grade-Automation
Merhaba,
Bu projede ilişkili tablo yapıları kullanılmıştır.
Projenin çalışabilmesi için VS2022 içerisinde Project-> Add New Item -> Data ->Dataset DB bağlantısı oluşturulmalıdır.
Dataset üzerinde oluşturulan TableAdapterlar ile CRUD işlemleri yapılmıştır. 
Dosyalar arasında bulunan DB'nin içeriğini, SQL Server Management Studio uygulamasının kurulu olduğu dizine gidip MSSQL içerisinde bulunan DATA klasörünün içerisine eklemelisiniz.

Tablolar arası ilişkiler:

Tbl_Kulüpler kulüpid -> Tbl_Ogrenciler -> OgrKulüp 

Tbl_Ogrenciler Ogrid -> Tbl_Notlar -> Ogrid

Tbl_Notlar Dersid -> Tbl_Dersler -> Dersid

Tbl_Dersler Dersid -> Tbl_Ogretmenler -> OgrtBrans 

Eklenilen DB verileriyle beraber yukarıdaki ilişkiler gelmezse, ilgili database içerisinde diyagram kısmında yukarıdaki ilişkiler oluşturulmalıdır.

Eğer kurulum konusunda sorun yaşarsanız bana mail adresimden ulaşabilirsiniz.

![image](https://github.com/OzcanFatihCan/Student-Grade-Automation/assets/93872480/11364d40-6d85-4303-b30a-5f725a46917f)
![image](https://github.com/OzcanFatihCan/Student-Grade-Automation/assets/93872480/e7439344-d51c-452f-9406-4b1fb1b50004)

Öğretmen paneli
![image](https://github.com/OzcanFatihCan/Student-Grade-Automation/assets/93872480/026683de-0c23-4814-9034-dd43e9f2ac02)
![image](https://github.com/OzcanFatihCan/Student-Grade-Automation/assets/93872480/38117272-e1a4-4fef-aaf5-17201e40a502)
![image](https://github.com/OzcanFatihCan/Student-Grade-Automation/assets/93872480/deb62d50-e35a-4a2e-81bd-bd57b60ea2f7)
![image](https://github.com/OzcanFatihCan/Student-Grade-Automation/assets/93872480/a565104c-22d8-4f8a-9ebc-278a0a6eee43)
![image](https://github.com/OzcanFatihCan/Student-Grade-Automation/assets/93872480/dc1bf52a-7614-4ba2-9052-b949af643a8b)


