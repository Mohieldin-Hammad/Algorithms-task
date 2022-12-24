namespace gui_sort_app
{
    public partial class Form1 : Form
    {
        
        public List<int> ListOfNumbers = new List<int>();
        
        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Insertion is failed successfully :)");
            }
            else
            {
                string num = textBox1.Text;
                ListOfNumbers.Add(int.Parse(num));
                textBox1.Text = "";
                if (textBox2.Text == string.Empty)
                {
                    textBox2.Text = num;
                }
                else
                {
                    textBox2.Text = textBox2.Text + ", " + num;
                }
            }
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListOfNumbers.Clear();
            textBox2.Text = "";
            textBox3.Text = "";
        }
        

        //private static List<int> insertion_sort(List<int> list)
        //{
        //    int n = list.Count();
        //    int key, i;
        //    for (int j = 1; j < n; j++)
        //    {
        //        key = list[j];
        //        i = j - 1;
        //        while(i >= 0 && list[i] > key)
        //        {
        //            list[i + 1] = list[i];
        //            i = i - 1;
        //        }
        //        list[i + 1] = key;
        //    }
        //    return list;
        //}

        private static void insertion_sort(int[] arr)
        {
            int n = arr.Length;
            int key, i;
            for (int j = 1; j < n; j++)
            {
                key = arr[j];
                i = j - 1;
                while (i >= 0 && arr[i] > key)
                {
                    arr[i + 1] = arr[i];
                    i = i - 1;
                }
                arr[i + 1] = key;
            }
        }

        private static void merge_sort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;
                merge_sort(arr, l, m);
                merge_sort(arr, m + 1, r);

                // Merge the sorted halves
                merge(arr, l, m, r);
            }
        }

        static void merge(int[] arr, int l, int m, int r)
        {
            int n1 = m - l + 1;
            int n2 = r - m;

            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            // Copy data to temp arrays
            for (i = 0; i < n1; ++i)
                L[i] = arr[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[m + 1 + j];

            
            i = 0;
            j = 0;
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            // Copy remaining elements of L[] if any
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }
            // Copy remaining elements of R[] if any
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] arr = ListOfNumbers.ToArray();
            if (radioButton1.Checked == true)
            {
                insertion_sort(arr);
                //ListOfNumbers = insertion_sort(ListOfNumbers);
                //textBox3.Text = string.Join(", ", ListOfNumbers.ToArray());
            }
            else if (radioButton2.Checked == true)
            { 
                merge_sort(arr, 0, arr.Length - 1);
                
            }
            textBox3.Text = string.Join(", ", arr);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && textBox1.Text != "")
            {
                button1_Click(this, new EventArgs());
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}