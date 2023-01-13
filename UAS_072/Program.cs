using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_072
{
    class Node
    {
        public int IdBrg;
        public string Nama;
        public string Jenis;
        public int Harga;
        public Node next;
    }
    class List
    {
        Node START;

        public List()
        {
            START = null;
        }

        public void addNote()
        {
            int ID;
            string nM;
            string JNS;
            int HR;
            Console.Write("\nMasukkan ID Barang : ");
            ID = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan Nama Barang:");
            nM = Console.ReadLine();
            Console.Write("\nMasukkan Jenis Barang:");
            JNS = Console.ReadLine();
            Console.Write("\nMasukkan Harga Barang : ");
            HR = Convert.ToInt32(Console.ReadLine());
            Node newnode = new Node();
            newnode.IdBrg = ID;
            newnode.Nama = nM;
            newnode.Jenis = JNS;
            newnode.Harga = HR;

            if (START == null || ID <= START.IdBrg)
            {
                if ((START != null) && (ID == START.IdBrg))
                {
                    Console.WriteLine("\nID Barang tidak diizinkan\n");
                    return;
                }
                newnode.next = START;
                START = newnode;
                return;
            }

            Node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (ID >= current.IdBrg))
            {
                if (ID == current.IdBrg)
                {
                    Console.WriteLine("\nID Barang tidak diizinkan\n");
                    return ;
                }
                previous = current;
                current = current.next;
            }
            newnode = current;
            previous.next = newnode;
        }
        public void traverse()
        {
            if (listEmpty())
            {
                Console.WriteLine("\nList kosong.\n");
            }
            else
            {
                Console.WriteLine("\nData didalam list yaitu: ");
                Node currentNode;
                for (currentNode = START; currentNode != null;
                    currentNode = currentNode.next)

                    Console.Write(currentNode.IdBrg + "" + currentNode.Nama + "\n");

                Console.WriteLine();
            }
        }
        public bool delNode(string JNS)
        {
            Node previous, current;
            previous = current = null;
            if (Search(JNS, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if (current == START)
                START = START.next;
            return true;
        }
        public bool Search(string JNS, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;

            while ((current != null) && (JNS != current.Jenis))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return (false);
            else
                return (true);
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List obj = new List();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Tambahkan data kedalam List ");
                    Console.WriteLine("2. Hapus data dari List");
                    Console.WriteLine("3. Melihat semua data yang ada di List");
                    Console.WriteLine("4. Mencari data yang ada didalam List");
                    Console.WriteLine("5. Exit");
                    Console.WriteLine("\nMasukkan pilihan (1-5) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNote();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("List kosong");
                                    break;
                                }
                                Console.Write("\nMasukkan jenis barang yang akan dihapus : " );
                                string JNS = Console.ReadLine();
                                Console.WriteLine();
                                if (obj.delNode(JNS) == false)
                                    Console.WriteLine("\n Jenis tidak ditemukan.");
                                else
                                    Console.WriteLine("Jenis yang dihapus" + JNS + "Deleted");

                            }
                            break ;
                        case '3':
                            {
                                obj.traverse();
                            }
                            break;
                        case '4':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList Kosong !");
                                    break;
                                }
                                Node provious, current;
                                provious = current = null;
                                Console.Write("\nMasukkan Jenis Barang yang akan dicari: ");
                                string JNS = Console.ReadLine();
                                if (obj.Search(JNS, ref provious, ref current) == false)
                                    Console.WriteLine("\nJenis tidak ditemukan.");
                                else
                                {
                                    Console.WriteLine("\nData ketemu");
                                    Console.WriteLine("\nID Barang: " + current.IdBrg);
                                    Console.WriteLine("\nNama: " + current.Nama);
                                    Console.WriteLine("\nJenis Barang: " + current.Jenis);
                                    Console.WriteLine("\nHarga Barang: " + current.Harga);
                                }
                            }
                            break;
                        case '5':
                            return;
                        default:
                            {
                                Console.WriteLine("\nPilihan Salah");
                                break ;
                            }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nCek data yang dimasukkan");
                }
            }
        }
    }
}

/* 2.Memakai algoritma Single linked list karna ingin memasukkan data yang tak terbatas jumlahnya dan algoritma lebih saya mengerti */ 
/* 3. Array dipakai untuk data yang memiliki nilai maksimum dan minimum sedangkan linked list jika ingin membuat data yang banyak jumlahnya  */
/* 4. FRONT, REAR */
/* 5. A. 16 sibling nya 53
 *       46 Sibling nya 55
 *       63 Sibling nya 70
 *       62 Sibling nya 64
 *    B. Metode Inorder 
 *      -> 41,16,25,53,46,42,55,60,74,65,63,62,70,64.*/
