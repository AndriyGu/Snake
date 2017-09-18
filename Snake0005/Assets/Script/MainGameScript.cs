using System;

using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


using System.Text;




public class MainGameScript : MonoBehaviour
{
    public GameObject Block;
   public Manager manager;
    string fileName;
    public Text ScoreText;
    public int lineQountity;
    public int columnQountity;

    public String nameButton;
    string filePass = Environment.CurrentDirectory+@"\\Assets\\StreamingAssets\\";
    GameObject[,] MapArea;
    public int score = 0;
    Telo[] Snake = new Telo[60];
    int SizeSnake = 0;
    int Dx = 0, Dy = 0;
    public float speedSnake = 0.6f;
    float RenderTime, //время перерисовки

    CurrentTime; //Текущее время
    public Lewel1 lewel1;
    public LevelManager levelManager;
    public Progress progress;
    public GameObject gameObj;
    public GameObject PanelLevelComplited;
    public GameObject CanvasGameProcess;
    public GameObject CanvasLevelChoose;
    public GameObject MainCamera;
    public GameObject ExitPanel;

    public bool buttonResumeCliced;

    public int numberLvl;
    public int scoreGrade;
    int chekButton = 1;






    public UIPanelComplited uIPanelComplited;



    void Start()
    {
        string currentDir = Environment.CurrentDirectory;
        
       // Debug.Log("CurrentDireckt" + currentDir);

        //Debug.Log("name level  61   " + Manager.Inst.name);
        fileName = ""+ Manager.Inst.name + "Level.txt";
        numberLvl = Int32.Parse(Manager.Inst.name);
        scoreGrade = 3* numberLvl;

        Time.timeScale = 1.0F;
        ScoreText.text = "Score: 0";

        lineQountity = lineCounter(filePass);
        columnQountity = columnCounter(filePass);
        MapArea = new GameObject[columnQountity, lineQountity];


       // Debug.Log("X=" + columnQountity + ";  Y=" + lineQountity);
        //Debug.Log("MapArea long" + MapArea.Length);
        //Debug.Log("Score = " + score + "scoregrade" + scoreGrade);
 GenMap();
        Vector3 CameraPose;

        // настраивем камеру

       
        if ((columnQountity / 2) * 2 == columnQountity)
        {
            CameraPose = new Vector3(columnQountity / 2-0.5f, lineQountity / 2, -1* Math.Max((columnQountity / 2), (lineQountity+8)));

        }
        else
        {
            CameraPose = new Vector3(columnQountity / 2, lineQountity / 2, -1 * Math.Max((columnQountity / 2), (lineQountity+8)));

        }


        double distans = (Math.Sqrt((columnQountity / 2) * (columnQountity / 2) + (lineQountity / 2) * (lineQountity / 2))); // (Mathf.Sin(MainCamera.fieldOfView * Mathf.Deg2Rad / 2f));

      // Debug.Log("Diagonal" + distans);

        //так как скрипт находиться на том же объекте то задаем позицию так

        this.transform.position = CameraPose;

        //перед заданием параметра Size его нужно получить из камеры

        Camera C = this.GetComponent<Camera>();// </ camera >;

        //задаем параметр

        C.orthographicSize = 10;
        for (int I = 0; I < 2; I++)
        {
            InputKey();
            //вызываем функцию добавления к змейке части

            GrowSnake();
        }

        CreateWall();
        for (int I = 0; I < 5; I++) { CreateEat(); InputKey(); }
        
    }

    void Update()
    {

        
        // movesnake();
        CurrentTime = Time.time;

        //Задаем координаты для камеры

        // Debug.Log("Line = " + lineQountity + "Column = " + columnQountity);

       
            ScoreText.text = "Score: " + score.ToString();
            DrawSnake();
            InputKey();
            CurrentTime = Time.time;

            if (score >= scoreGrade & chekButton==1) // проверяет была ли нажата кнопка "OK" из UIPanelComplited
            {

           // Debug.Log("какого хуя???"+ "   buttonResumeCliced  " + buttonResumeCliced);
                PanelLevelComplited.SetActive(true);
                Time.timeScale = 0.0F;
            //  progress.level = progress.level + 1;
            Manager.Inst.countUnlockedLevel=numberLvl+1;
            buttonResumeCliced = false;
            chekButton = 0;
            }
       
        float alpha = CurrentTime - RenderTime;
            // Debug.Log("CurrentTime = " + CurrentTime + "   RenderTime = " + RenderTime + "====  " + (CurrentTime - RenderTime));
            if (alpha > speedSnake)

            {
                // DrawSnake();
                InputKey();
                //Двигаем персонажа если возможно

                movesnake();

                //запоминаем время когда двинули персонажа

                RenderTime = Time.time;
                TestStep();

                InputKey();

            }

            //проверяем больше ли текущее значение очков перед т
            if (score>=scoreGrade && Manager.Inst.mas[numberLvl, 1]<score)
        {

            //  Массив значений Г 
            //                  | колличество очков
            //                  L 
            //
            //


            Manager.Inst.mas[numberLvl, 1] = score;
           // Debug.Log("Score saved  " + score);
        }
       
       

        
        InputKey();

    }


   



    public int lineCounter(string filePass)
    {

        int lineCount = 0;
        try
        {
            lineCount = File.ReadAllLines(filePass + fileName).Length;
           // Debug.Log("line");
        }
        catch (Exception e)
        {

        }


        return lineCount;
    }


    public int columnCounter(string filePass)
    {
        Console.WriteLine("lineLengthCounter " + "begin");

        int lineMaxLength = 0;
        try
        {
            string[] readText = File.ReadAllLines(filePass + fileName, Encoding.UTF8);
            foreach (string s in readText)
            {
                Console.WriteLine("s.Length = " + s.Length);
                if (lineMaxLength < s.Length) { lineMaxLength = s.Length; }

            }


            //while ((System.IO.File.ReadLines(filePass)) != null) //читаем по одной линии(строке) пока не вычитаем все из потока (пока не достигнем конца файла)
            //        {
            //            if (lineMaxLength < line.Length) { lineMaxLength = line.Length; }
            //        }


        }

        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        Console.WriteLine("Max Length: " + lineMaxLength);
        return lineMaxLength;
    }


    void GenMap()
    {
        //точка отсчета

        Vector3 PointStart = new Vector3(0, 0, 0);

        //запускаем цикл расстановки по Y

        for (int Y = 0; Y < lineQountity; Y++)
        {

            //запускаем цикл расстановки по X

            for (int X = 0; X < columnQountity; X++)
            {

                //сдвигаем точку
                PointStart = new Vector3(X, Y, 0);

                //создаем блок в указанном месте

                MapArea[X, Y] = (GameObject)Instantiate(Block, PointStart, Quaternion.identity);

            }

        }

    }

    struct Telo

    {

        public int IndexX, IndexY;

    }

    //функция получения цвета у объекта
    int GetColor(GameObject O)
    {

        //читаем нужный нам компонент из объекта

        MyMap ComonentObject = O.GetComponent<MyMap>();

        //получаем номер используемой картинки

        int Imgcolor = ComonentObject.IndexImg;

        //возвращаем цвет выбранного блока

        return Imgcolor;

    }

    //задание картинки блоку
    void SetColor(GameObject O, int Set_color)

    {

        //читаем нужный нам компонент из объекта

        MyMap ComonentObject = O.GetComponent<MyMap>();

        //Задаем номер используемой картинки

        ComonentObject.IndexImg = Set_color;

    }

    void GrowSnake()
    {

        //смотрим какой длинны хвост

        if (SizeSnake == 0)

        {

            //стартовая точка будет 10 10 примерно центр экрана

            Snake[SizeSnake].IndexX = 3;

            Snake[SizeSnake].IndexY = 3;

        }

        else

        {

            //если хвост есть то добавляем его к последней части

            Snake[SizeSnake].IndexX = Snake[SizeSnake - 1].IndexX;

            Snake[SizeSnake].IndexY = Snake[SizeSnake - 1].IndexY;

        }

        //увеличиваем длину
        SizeSnake++;

    }

    void DrawSnake()

    {

        //перебираем весь хвост пока не дойдем до его максимальной длинны

        for (int I = 1; I < SizeSnake; I++)
        {

            //задаем картинку блоку вида 0 картинки

            SetColor(MapArea[Snake[I].IndexX, Snake[I].IndexY], 2);
        }

        //если змейка существует и ее размер >0

        if (SizeSnake > 0)
        {

            //Для 0 блока змейки задаем что это голова

            SetColor(MapArea[Snake[0].IndexX, Snake[0].IndexY], 1);
        }

    }

    void InputKey()

    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0.0F;
            ExitPanel.SetActive(true);
            ///Application.Quit();
        }

        //получаем что нажал игрок по горизонтали по Х

        float X = Input.GetAxis("Horizontal");

        //если X больше 0 значит задаем DX будет равен 1

        if (X > 0)

        {

            Dx = 1; Dy = 0;

        }

        //если X меньше 0 значит задаем DX будет равен -1

        else if (X < 0)

        {

            Dx = -1; Dy = 0;

        }

        //получаем что нажал игрок по вертикали по У

        float Y = Input.GetAxis("Vertical");

        //если Y больше 0 значит задаем DY будет равен -1

        if (Y > 0)

        {

            Dx = 0; Dy = -1;

        }

        //если Y меньше 0 значит задаем DY будет равен 1

        else if (Y < 0)

        {

            Dx = 0; Dy = 1;

        }

    }

    //двигаем персонажа
    void movesnake()

    {
        InputKey();//если указано направление для движения то двигаемся

        if ((Dx != 0) || (Dy != 0))

        {   //затираем прозрачным цветом последнюю часть хвоста

            int L = SizeSnake - 1;

            //если змейка существует

            if (L > 0)


                //закрашиваем цвет

                SetColor(MapArea[Snake[L].IndexX, Snake[L].IndexY], 0);

            //смещаем змею с хвоста в сторону головы
            InputKey();

            for (int I = SizeSnake - 1; I > 0; I--)
            {
                InputKey();
                Snake[I] = Snake[I - 1];
            }

            //двигаем голову в новую точку
            InputKey();

            Snake[0].IndexX += Dx;
            InputKey();

            Snake[0].IndexY -= Dy;

            //если мы вылезли на граници поля то 2 варианат 1 мы вылезаем с другой стороны либо умераем

            //Проверяем координаты по оси X

            if (Snake[0].IndexX > columnQountity) Snake[0].IndexX = 0;

            if (Snake[0].IndexX < 0) Snake[0].IndexX = columnQountity;

            //проверяем по оси Y

            if (Snake[0].IndexY > lineQountity) Snake[0].IndexY = 0;

            if (Snake[0].IndexY < 0) Snake[0].IndexY = lineQountity;



        }
    }

    void CreateEat()

    {

        //флаг смогли ли установить яблоко

        bool Insert_Apple = true;

        //параметры яблока

        int CoordX; //координата бонуса по оси Х

        int CoordY; //координата бонуса по оси У

        //выполняем действие пока яблоко не найдет себе место

        while (Insert_Apple)

        {

            //получаем случайные 2 координаты

            CoordX = UnityEngine.Random.Range(0, columnQountity);

            CoordY = UnityEngine.Random.Range(0, lineQountity);

            // Debug.Log("X " + CoordX + " Y " + CoordY);

            //если полученные координаты не выходят за границы массива

            //смотрим какой цвет у части карты


            // Debug.Log("MapArea.GetLength = " + MapArea.Length);

            int cvet = GetColor(MapArea[CoordX, CoordY]);

            //если в блоке картинка с номером 0

            if (cvet == 0)

            {

                //задаем цвет картинки



                SetColor(MapArea[CoordX, CoordY], 3);

                //и останавливаем цикл установки яблока

                Insert_Apple = false;

            }

        }

    }


    void TestStep()
    {
        InputKey();

        //получаем место куда должна переместится голова

        int HeadX = Snake[0].IndexX,

        HeadY = Snake[0].IndexY;

        //смотрим что находилось в данной точке
        InputKey();
        int Step = GetColor(MapArea[HeadX, HeadY]);

        //проверяем куда наступил персонаж

        switch (Step)

        {

            //если наступили на яблоко то запускаем рост змеи


            case 2:
                { SceneManager.LoadScene(0); }
                break;
            case 3:
                {
                    GrowSnake();
                    InputKey();

                    //помещаем яблоко в другом месте
                    score++;
                    CreateEat();
                }
                break;
            case 4:
                { SceneManager.LoadScene(0); }
                break;

        }

    }



    public void CreateWall()
    {
       // Debug.Log("CreateWall");


        string[] readText = File.ReadAllLines(filePass + fileName, Encoding.UTF8);
        //string[] readText = readText0;
        //for(int d=0, c=readText0.Length; d<readText0.Length; d++, c--)
        //{
        //    readText[c]=readText0[d];
        //}
        int i = readText.Length-1;
        foreach (string s in readText)
        {
            char[] arrTemp = s.ToCharArray(0, s.Length);

            for (int j = 0; j < arrTemp.Length; j++)
            {
                //Debug.Log("i   "+i+"   j   "+j);
                if (arrTemp[j].Equals('w'))
                {
                    SetColor(MapArea[j,  i], 4);
                }

            }

            //string sss = arrTemp[];
            //Debug.Log(arrTemp.ToString());
            i--;
        }

        // Console.WriteLine("Scale arr = " + readText.Length + "  " + readText[0].Length);



    }

}
