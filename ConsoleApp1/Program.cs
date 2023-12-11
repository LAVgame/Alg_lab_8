using System;

class InversionCount
{
    public static int CountInversions(int[] arr)
    {
        if (arr == null || arr.Length <= 1)
        {
            return 0; // Нет инверсий в пустом массиве или массиве из одного элемента
        }

        int[] temp = new int[arr.Length];
        return MergeSortAndCount(arr, temp, 0, arr.Length - 1);
    }

    private static int MergeSortAndCount(int[] arr, int[] temp, int left, int right)
    {
        int count = 0;

        if (left < right)
        {
            int mid = (left + right) / 2;

            // Рекурсивно сортируем и подсчитываем инверсии в левой и правой половинах массива
            count += MergeSortAndCount(arr, temp, left, mid);
            count += MergeSortAndCount(arr, temp, mid + 1, right);

            // Объединяем две отсортированные половины и подсчитываем инверсии
            count += MergeAndCount(arr, temp, left, mid, right);
        }

        return count;
    }

    private static int MergeAndCount(int[] arr, int[] temp, int left, int mid, int right)
    {
        int i = left;
        int j = mid + 1;
        int k = left;
        int count = 0;

        while (i <= mid && j <= right)
        {
            if (arr[i] <= arr[j])
            {
                temp[k++] = arr[i++];
            }
            else
            {
                // Если arr[i] > arr[j], то у нас есть инверсия
                temp[k++] = arr[j++];
                count += (mid - i + 1);
            }
        }

        // Завершаем копирование оставшихся элементов, если они есть
        while (i <= mid)
        {
            temp[k++] = arr[i++];
        }

        while (j <= right)
        {
            temp[k++] = arr[j++];
        }

        // Копируем отсортированные элементы обратно в оригинальный массив
        for (int l = left; l <= right; l++)
        {
            arr[l] = temp[l];
        }

        return count;
    }

    static void Main()
    {
        int[] arr = { 1, 20, 6, 4, 5 };
        int inversionCount = CountInversions(arr);

        Console.WriteLine("Количество инверсий в массиве: " + inversionCount);
    }
}
