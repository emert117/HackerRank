    public static void almostSorted(List<int> arr)
    {
        List<int> swapArr = arr.Select(x => x).ToList();
            List<int> reverseArr = arr.Select(x => x).ToList();
            int l = 0, r = 0;
            // iterate through array
            for (int i = 0; i < (arr.Count - 1); i++)
            {

                // compare values
                if (arr[i] < arr[i + 1]) continue;
                l = i;

                int index = (i + 1);
                while (index < (arr.Count - 1) && arr[i] > arr[index + 1]) index++;
                r = index;

                // try swapping
                int temp = swapArr[index];
                swapArr[index] = swapArr[i];
                swapArr[i] = temp;

                // try reversing
                for (int j = 0; j <= ((index - i) / 2); j++)
                {
                    temp = reverseArr[i + j];
                    reverseArr[i + j] = reverseArr[index - j];
                    reverseArr[index - j] = temp;
                }

                // only one operation allowed so break out of loop
                break;
            }
            // test if either is sorted
            int x = 1;
            int y = 1;
            while (x < swapArr.Count && swapArr[x] > swapArr[x - 1]) x++;
            while (y < reverseArr.Count && reverseArr[y] > reverseArr[y - 1]) y++;

            if (x == swapArr.Count)
            {
                Console.WriteLine("yes");
                Console.WriteLine($"swap {l + 1} {r + 1}");
            }
            else if (y == reverseArr.Count)
            {
                Console.WriteLine("yes");
                Console.WriteLine($"reverse {l + 1} {r + 1}");
            }
            else Console.WriteLine("no");

    }
