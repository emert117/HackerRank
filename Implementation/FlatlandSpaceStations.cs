static int flatlandSpaceStations(int n, int[] c) {
        if(n == c.Length)
            return 0;
        int count = 0, max = 0;
        bool first = true;
        for(int i = 0; i < n; i++){
            if(!c.Contains(i)){
                count++;
            }else{
                first = false;
                count = count%2 == 0 ? count/2 : (count/2)+1;
                max = max < count ? count : max;
                count = 0;
            }
            
            if(first)
                max = max < count ? count : max;
        }
        max = max < count ? count : max;
        return max;
    }