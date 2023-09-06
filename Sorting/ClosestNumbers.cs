    public static List<int> closestNumbers(List<int> arr)
    {
        arr.Sort();
        int min = arr[arr.Count - 1];
        List<int> result = new List<int>();
        
        for(int i = 0; i < (arr.Count - 1); i++){
            int diff = Math.Abs(arr[i] - arr[i + 1]);
            if(diff < min) {
                min = diff;
                result.Clear();
                result.Add(arr[i]); 
                result.Add(arr[i + 1]);
            } else if(diff == min) {
                result.Add(arr[i]);
                result.Add(arr[i + 1]);
            }
        }
        return result;
    }