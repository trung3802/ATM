using System;
using System.Text;

class Program
{
    static void Main()
    {
        // Thiết lập encoding UTF-8 cho Console
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        // Nhập số tiền cần rút từ người dùng
        Console.Write("Nhập số tiền cần rút: ");
        if (!int.TryParse(Console.ReadLine(), out int tien) || tien <= 0)
        {
            Console.WriteLine("Số tiền không hợp lệ.");
            return;
        }

        // Các tờ tiền có sẵn
        int[] mang = { 50, 20, 10, 5, 2, 1 }; // Thêm mệnh giá 2 và 1 vào mảng

        // Sắp xếp các tờ tiền giảm dần
        Array.Sort(mang, (a, b) => b.CompareTo(a));

        // Tính số tờ tiền cần rút cho mỗi mệnh giá và số bước lặp
        int[] result = new int[mang.Length];
        int soBuocLap = 0; // Biến đếm số bước lặp
        int i = 0; // Chỉ số của mệnh giá hiện tại
        while (tien > 0 && i < mang.Length)
        {
            // Tính số tờ tiền cần rút của mỗi mệnh giá
            result[i] = tien / mang[i];

            // Cập nhật số tiền còn lại
            tien %= mang[i];

            // Tăng số bước lặp
            soBuocLap++;

            // Hiển thị giải thích từng bước
            Console.WriteLine($"Bước {soBuocLap}: Rút {result[i]} tờ {mang[i]} VNĐ, còn lại {tien} VNĐ.");

            // Chuyển sang mệnh giá tiếp theo
            i++;
        }

        // Hiển thị kết quả và số bước lặp
        Console.WriteLine("Số tờ tiền cần rút:");
        for (i = 0; i < mang.Length; i++)
        {
            Console.WriteLine($"{mang[i]} - {result[i]} tờ");
        }

        Console.WriteLine($"Số bước lặp: {soBuocLap}");
    }
}
