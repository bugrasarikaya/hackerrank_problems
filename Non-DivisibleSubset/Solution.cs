namespace Non_DivisibleSubset {
	internal class Result {
		public static void loop(List<List<int>> list_nested, List<int> list, int count_loop) {
			for (int i = 0; i < list.Count; i++) {
				for (int j = i + 1; j < list.Count; j++) {
					for (int k = j + 1; k < list.Count; k++) {
						list_nested.Add(new List<int>() { list[i], list[j], list[k] });
					}
				}
			}
		}
		public static int nonDivisibleSubset(int k, List<int> s) {
			for (int i = s.Count; i > 0; i--) foreach (List<int> list in GeneratePermutation(new List<List<int>>(), s, new int[i], i, i)) if (CheckNonDivisible(list, k)) return list.Count;
			return 0;
		}
		public static List<List<int>> GeneratePermutation(List<List<int>> list_nested, List<int> list, int[] array_index, int count_original_loop, int count_loop) {
			if (count_loop == 0) {
				List<int> list_inner = new();
				foreach (int index in array_index) list_inner.Add(list[index]);
				list_nested.Add(list_inner);
			} else {
				for (int i = count_original_loop == count_loop ? 0 : array_index[count_original_loop - count_loop - 1] + 1; i < list.Count; i++) {
					array_index[count_original_loop - count_loop] = i;
					GeneratePermutation(list_nested, list, array_index, count_original_loop, count_loop - 1);
				}
			}
			return list_nested;
		}
		public static bool CheckNonDivisible(List<int> list, int num) {
			for (int i = 0; i < list.Count; i++) for (int j = i + 1; j < list.Count; j++) if ((list[i] + list[j]) % num == 0) return false;
			return true;
		}
	}
	internal class Solution {
		public static void Main(string[] args) {
			//Console.WriteLine(Result.nonDivisibleSubset(5, new List<int> { 2, 7, 12, 17, 22 }));
			TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
			string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
			int n = Convert.ToInt32(firstMultipleInput[0]);
			int k = Convert.ToInt32(firstMultipleInput[1]);
			List<int> s = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();
			int result = Result.nonDivisibleSubset(k, s);
			textWriter.WriteLine(result);
			textWriter.Flush();
			textWriter.Close();
		}
	}
}