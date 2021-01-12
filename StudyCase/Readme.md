Nama : Naima Zulfa
NIM  : 19.11.2735
Kelas: 19 Informatika 03

# OrderFood
Aplikasi ini berfungsi untuk memesan suatu item/barang dan menjumlahkan total harga barang yang dipesan oleh si pembeli.

### Fungsi
* User dapat melihat daftar makanan yang ditawarkan
* User dapat memasukkan atau menghapus makanan pilihan ke dalam keranjang
* User dapat melihat subtotal makanan yang terdapat pada keranjang
* User dapat melihat daftar voucher yang ditawarkan
* User dapat menggunakan salah satu voucher
* User dapat melihat harga total termasuk potongannya

### Class Diagram
![Class Diagram1](ClassDiagram1.png)

### How Does It Works?
Saat aplikasi pertama kali dibuka user akan disuguhkan oleh tampilah awal dari aplikasi yang berisi Keranjang, Voucher, Sub Total, dan Total Harga. Yang mana user dapat memilih item yang akan diambil dengan mengklik tombol Tambah Pesanan. 
Serta user juga akan diberikan voucher discon dengan mengklik tombol Pilih Voucher, vouche ini secara otomatis akan mengurangi total harga sebelumnya.

Disini kita akan memanggil Keranjang Belanja dan listBox pada Item Penawaran dan Voucher.
```csharp
public MainWindow()
        {
            InitializeComponent();

            payment = new Payment(this);

            KeranjangBelanja keranjangBelanja = new KeranjangBelanja(payment, this);

            controller = new MainWindowController(keranjangBelanja);

            listBoxPesanan.ItemsSource = controller.getSelectedItems();
            listBoxPakaiVoucher.ItemsSource = controller.getSelectedVouchers();

            initializeView();
        }
```
Pada `Penawaran.xaml.cs` terdapat code seperti yang dibawah, code ini berfungsi untuk item daftar menu yang nanti akan ditambahkan di listBox.
```csharp
private void generateContentPenawaran()
        {
            Item coffeLate = new Item("Coffe Late", 30000);
            Item blackTea = new Item("BlackTea", 20000);
            Item pizza = new Item("Pizza", 75000);
            Item milkShake = new Item("Milk Shake", 15000);
            Item friedFrice = new Item("Fried Frice Special", 45000);
            Item watermelonJuice = new Item("Watermelon Juice", 25000);
            Item lemonSquash = new Item("Lemon Squash", 30000);

            Penawarancontroller.addItem(coffeLate);
            Penawarancontroller.addItem(blackTea);
            Penawarancontroller.addItem(pizza);
            Penawarancontroller.addItem(milkShake);
            Penawarancontroller.addItem(friedFrice);
            Penawarancontroller.addItem(watermelonJuice);
            Penawarancontroller.addItem(lemonSquash);

            listPenawaran.Items.Refresh();
        }
```
`MainWindowController.cs` berfungsi sebagai pengontrol Keranjang Belanja agar nanti dapat berfungsi dengan baik. Kemudian `PilihVoucher.xaml.cs` yang mempunyai fungsi mirip seperti Penawaran, hanya saja ini digunakan untuk Voucher yang mana nantinya akan ditampilkan pada listBox.

Jadi item-item yang dipilih dimasukkan ke dalam listBox. Setiap item yang ditambahkan akan membuat total harga semakin besar, begitu juga jika item dikurang/dihapus maka total harga juga akan berkurang. Kemudian setiap Voucher yang dipilih akan dihitung potongannya secara otomatis dengan perhitungan algoritma. Dan akan didapatlah Total keseluruhan harga yang harus dibayar.

Jika button Voucher di klik maka akan memunculkan halaman Daftar Voucher yang bisa kita pilih.
```
 private void OnPilihVoucherClicked(object sender, RoutedEventArgs e)
        {
            PilihVoucher pilihVoucherWindow = new PilihVoucher();
            pilihVoucherWindow.SetOnItemSelectedListener(this);
            pilihVoucherWindow.Show();
        }
```
Begitu pula dengan button Tambah Pesanan jika di klik maka akan memunculkan halaman list penawaran.
```
private void onButtonAddItemClicked(object sender, RoutedEventArgs e)
        {
            Penawaran penawaranWindow = new Penawaran();
            penawaranWindow.SetOnItemSelectedListener(this);
            penawaranWindow.Show();
```
