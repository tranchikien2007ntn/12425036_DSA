# Buổi 01 – Đệ quy

- **Họ tên:** Trần Chí Kiên
- **Lớp:** 124251
- **Môn:** Cấu trúc dữ liệu và giải thuật (211131)
- **Nội dung:** Bài tập chương 1, 2, 3 (sgk CTDLGT)
- **Môi trường:** C# Console App, .NET Framework 4.7.2, Visual Studio

## Cấu trúc thư mục

```text
Buoi01_DeQuy/
├── README.md
├── BTChuong1sgkCTDLGT/    # Chương 1: 5 bài
├── BTchuong2sgkCTDLGT/    # Chương 2: 5 bài
└── BTchuong3sgkCTDLGT/    # Chương 3: 8 bài
```

Mỗi thư mục chương là một project Console riêng (`.slnx` + `.csproj`); mã nguồn mỗi bài nằm trong file `BaiX.cs`.

## Cách chạy

1. Mở file `.slnx` của chương cần chạy bằng Visual Studio.
2. Trong `Program.cs`, bỏ dấu `//` ở dòng `BaiX.Chay();` của bài cần chạy, các bài còn lại để comment.
3. Nhấn **Ctrl + F5** để chạy và nhập dữ liệu theo yêu cầu trên màn hình console.

---

## Kết quả chạy

### Chương 1 – `BTChuong1sgkCTDLGT`

#### Bài 1 – Số lớn nhất, số nhỏ nhất của mảng ngẫu nhiên
Sinh mảng 1000 số nguyên ngẫu nhiên trong đoạn [0, 9999], tìm số lớn nhất và số nhỏ nhất.

```text
<<< CHƯA CÓ KẾT QUẢ: chạy bài này rồi dán output vào đây (kết quả ngẫu nhiên mỗi lần chạy) >>>
```

#### Bài 2 – FizzBuzz từ 1 đến 100
In `Fizz` với bội của 3, `Buzz` với bội của 5, `FizzBuzz` với bội của cả 3 và 5, còn lại in chính số đó.

<details>
<summary>Xem kết quả (100 dòng)</summary>

```text
1
2
Fizz
4
Buzz
Fizz
7
8
Fizz
Buzz
11
Fizz
13
14
FizzBuzz
16
17
Fizz
19
Buzz
Fizz
22
23
Fizz
Buzz
26
Fizz
28
29
FizzBuzz
31
32
Fizz
34
Buzz
Fizz
37
38
Fizz
Buzz
41
Fizz
43
44
FizzBuzz
46
47
Fizz
49
Buzz
Fizz
52
53
Fizz
Buzz
56
Fizz
58
59
FizzBuzz
61
62
Fizz
64
Buzz
Fizz
67
68
Fizz
Buzz
71
Fizz
73
74
FizzBuzz
76
77
Fizz
79
Buzz
Fizz
82
83
Fizz
Buzz
86
Fizz
88
89
FizzBuzz
91
92
Fizz
94
Buzz
Fizz
97
98
Fizz
Buzz
```

</details>

#### Bài 3 – Đảo ngược chuỗi
Nhập một chuỗi từ bàn phím và in chuỗi đảo ngược.

```text
Nhap chuoi: Cau truc du lieu va giai thuat
Chuoi dao nguoc: tauht iaig av ueil ud curt uaC
```

#### Bài 4 – Sắp xếp mảng ngẫu nhiên
Sinh mảng 1000 số nguyên ngẫu nhiên, in mảng ban đầu, sắp xếp tăng dần rồi in lại.

```text
<<< CHƯA CÓ KẾT QUẢ: chạy bài này rồi dán output vào đây (output rất dài: 1000 số x 2 lần, có thể dán phần đầu mỗi mảng) >>>
```

#### Bài 5 – Số Fibonacci thứ n
Tìm số Fibonacci thứ n (1 ≤ n ≤ 93) của dãy 0, 1, 1, 2, 3, 5, … bằng vòng lặp.

```text
Nhap so nguyen duong n (1 - 93): 10
So Fibonacci thu 10 la: 34

Nhap so nguyen duong n (1 - 93): 93
So Fibonacci thu 93 la: 7540113804746346429
```

---

### Chương 2 – `BTchuong2sgkCTDLGT`

Các bài chương 2 vừa in kết quả vừa đo thời gian chạy thực nghiệm nên kết quả phụ thuộc máy.

#### Bài 1 – Tháp Hà Nội
Đếm số bước chuyển đĩa bằng đệ quy và bằng vòng lặp (dùng stack), so sánh với 2^n − 1; có bảng thời gian thực nghiệm với n = 10, 15, 20, 25.

```text
<<< CHƯA CÓ KẾT QUẢ: chạy bài này (gợi ý nhập n = 3) rồi dán toàn bộ output vào đây >>>
```

#### Bài 2 – Tìm kiếm nhị phân
So sánh tìm kiếm nhị phân (lặp, đệ quy) với tìm kiếm tuyến tính trên mảng mẫu `2, 5, 8, 12, 16, 23, 38, 56, 72, 91`; có bảng thời gian thực nghiệm với n = 10^5, 10^6, 10^7.

```text
<<< CHƯA CÓ KẾT QUẢ: chạy bài này (gợi ý nhập giá trị cần tìm = 23) rồi dán toàn bộ output vào đây >>>
```

#### Bài 3 – Kiểm tra số nguyên tố
Ba cách: duyệt từ 2 đến n−1, duyệt từ 2 đến √n, thuật toán Miller–Rabin; có bảng thời gian thực nghiệm.

```text
<<< CHƯA CÓ KẾT QUẢ: chạy bài này (gợi ý nhập n = 1000003) rồi dán toàn bộ output vào đây >>>
```

#### Bài 4 – Liệt kê số hoàn hảo nhỏ hơn N
Ba cách: duyệt ước từ 1 đến i−1, duyệt ước đến √i, công thức Euclid–Euler; có bảng thời gian thực nghiệm.

```text
<<< CHƯA CÓ KẾT QUẢ: chạy bài này (gợi ý nhập N = 10000) rồi dán toàn bộ output vào đây >>>
```

#### Bài 5 – Số Fibonacci thứ n
Bốn cách: đệ quy trực tiếp, vòng lặp, đệ quy có nhớ, lũy thừa ma trận; có bảng thời gian thực nghiệm (tính F(n) mod 1.000.000.007).

```text
<<< CHƯA CÓ KẾT QUẢ: chạy bài này (gợi ý nhập n = 30) rồi dán toàn bộ output vào đây >>>
```

---

### Chương 3 – `BTchuong3sgkCTDLGT`

#### Bài 1 – S(n) = 1 + 2 + 3 + … + n
Tính bằng đệ quy, đối chiếu với công thức n(n+1)/2.

```text
=== BAI 1: S(n) = 1 + 2 + 3 + ... + n ===
Nhap n (1 - 5000): 100
S(100) = 5050
Kiem tra bang cong thuc n(n+1)/2 = 5050
```

#### Bài 2 – S(n) = 1 + 2² + 3² + … + n²
Tính bằng đệ quy, đối chiếu với công thức n(n+1)(2n+1)/6.

```text
=== BAI 2: S(n) = 1 + 2^2 + 3^2 + ... + n^2 ===
Nhap n (1 - 5000): 100
S(100) = 338350
Kiem tra bang cong thuc n(n+1)(2n+1)/6 = 338350
```

#### Bài 3 – S(n) = 1 + 1/2 + 1/3 + … + 1/n

```text
=== BAI 3: S(n) = 1 + 1/2 + 1/3 + ... + 1/n ===
Nhap n (1 - 5000): 10
S(10) = 2.928968
```

#### Bài 4 – S(x, n) = xⁿ
Tính lũy thừa bằng đệ quy chia đôi số mũ, hỗ trợ cả n âm.

```text
=== BAI 4: S(x, n) = x^n ===
Nhap x: 2
Nhap n (-100000 den 100000): 10
S(2, 10) = 1024
```

#### Bài 5 – Ước lẻ lớn nhất của n

```text
=== BAI 5: UOC LE LON NHAT CUA n ===
Nhap so nguyen duong n: 48
Uoc le lon nhat cua 48 la 3
```

#### Bài 6 – Ước chung lớn nhất (Euclid)

```text
=== BAI 6: UOC CHUNG LON NHAT (EUCLID) ===
Nhap a (so nguyen duong): 48
Nhap b (so nguyen duong): 18
UCLN(48, 18) = 6
```

#### Bài 7 – Đếm số chữ số của n

```text
=== BAI 7: DEM SO CHU SO CUA n ===
Nhap so nguyen duong n: 12345
So 12345 co 5 chu so
```

#### Bài 8 – S(n) = √(1 + √(2 + √(3 + … + √n)))

```text
=== BAI 8: S(n) = sqrt(1 + sqrt(2 + sqrt(3 + ... + sqrt(n)))) ===
Nhap n (1 - 5000): 5
S(5) = 1.756238
```
