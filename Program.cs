using System.ComponentModel.Design.Serialization;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace algorithm404
{
    internal class Program
    {
        static void Main(string[] args)
        {
            node node1 = new node("iman",135322,1);
            tree tree1 = new tree(node1);
            
        }
    }
    class node
    {
        public int id;
        public string work;
        public int priority;

        public node left = null;
        public node right = null;
        public node parent = null;
        public node(string work, int id, int priority)
        {
            this.work = work;
            this.id = id;
            this.priority = priority;
        }
    }
    class tree
    {
        public node rishe;
        public tree(node vorudi)
        {
            rishe = new node(vorudi.work, vorudi.id, vorudi.priority);
        }
        public void insertbst(node vorudi)
        {
            node y = null;
            node x = rishe.parent;
            while (x != null)
            {
                y = x;
                if (x.id > vorudi.id)
                    x = x.left;
                else
                    x = x.right;
            }
            vorudi.parent = y;
            if (y == null)
                rishe = vorudi;
            else if (y.id > vorudi.id)
                y.left = vorudi;
            else
                y.right = vorudi;
        }
        public static void printinorder(node rishe1)
        {
            if (rishe1 != null)
            printinorder(rishe1.left);
            Console.WriteLine("name:"+ rishe1.work ,"id:"+ rishe1.id,"priority:"+ rishe1.priority);
            printinorder (rishe1.right);
        }
        public  node searchbst(node vorudi ,int idgere)
        {
            if (vorudi == null || idgere == rishe.id)
                return vorudi;
            if(idgere < vorudi.id)
                return searchbst(vorudi.left, idgere);
            else
                return searchbst(vorudi.right, idgere);
        }
        public void transplant (node ghabli , node jadid)
        {
            if (ghabli.parent == null)  //shart rishe budan gere
                rishe = jadid;
            else if (ghabli == ghabli.parent.left)  // shart farzand chap
                ghabli.parent.left = jadid;
            else   // shart farzand rast
                ghabli.parent.right = jadid;
            if (jadid != null)    //shart nadashtan farzand 
                jadid.parent = ghabli.parent;
        }
        public static node Minimum(node vorudi)
        {
            while (vorudi.left != null) 
                vorudi = vorudi.left;
            return vorudi;
        }
        public void deletenodebst(int idgere)
        {
            node hadaf = searchbst(rishe,idgere);
            if (hadaf.left == null)         // shart farzand rast
                transplant(hadaf,hadaf.right);
            else if (hadaf.right == null)   // shart farzand chap
                transplant(hadaf , hadaf.left);

            else
            {
                node janeshin = Minimum(hadaf.right);
                if (janeshin.parent != hadaf)
                {
                    transplant (janeshin,janeshin.right);
                    janeshin.right = hadaf.right;
                    janeshin.right.parent = janeshin;
                }
                transplant(hadaf, janeshin);
                janeshin.left = hadaf.left;
                if (janeshin.left != null)
                    janeshin.left.parent = janeshin;
            }

        }
    }
    class maxheap
    {
        public List<node> heap;


        public maxheap()
        {
            heap = new List<node>();
        }
        public void maxheapify(int vorudi)
        {
            int heapsize = heap.Count;
            node chap = heap[vorudi].left;
            node rast = heap[vorudi].right;
            int largest = 0;
            if (chap.priority <= heapsize && heap[chap.priority].priority > heap[largest].priority )
                largest=chap.priority;
            if (rast.priority <= heapsize && heap[rast.priority].priority > heap[largest].priority)
                largest =rast.priority;
            if (largest != vorudi)
            {
                node movaghat = heap[vorudi];
                heap[vorudi] = heap[largest];
                heap[largest] = movaghat;
                maxheapify(largest);
            }
        }
        public void buildmaxheap()
        {
            int heapsize = heap.Count;
            for (int i = heap.Count / 2; i > 2; i--)
                maxheapify(i);
        }
        public void heapsort()
        {
            int heapsize = heap.Count;
            buildmaxheap();
            for (int i = heap.Count ;i>2 ;i--)
            {
                int movaghat = heap[0].priority;
                heap[0] = heap[i];
                heap[i].priority =movaghat;
                heapsize = heapsize - 1;
                maxheapify(1);
            }
        }

    }
}