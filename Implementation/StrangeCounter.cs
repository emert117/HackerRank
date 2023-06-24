public static long strangeCounter(long t)
{
    long last = 3;
    long factor = 3;   
    while(t>last) {
        factor *=2;
        last = (factor -2)*2+1;  
    }       
    return last - t +1;   

}