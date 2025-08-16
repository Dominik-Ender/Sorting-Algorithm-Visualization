class GenerateRandomArray {

    public static int[] GetRandomArray(int numberOfElements) {
        Random random = new();

        int[] array = new int[numberOfElements];

        for(int i = 0; i < array.Length; i++) {
            array[i] = i + 1;
        }   

        for (int i = 0; i < array.Length; i++) {
            int j = random.Next(1, numberOfElements - 1);
            int temp = array[i];

            array[i] = array[j];
            array[j] = temp;

        }
        return array;
    }
}
