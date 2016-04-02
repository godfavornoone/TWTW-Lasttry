using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;

public class textManager : MonoBehaviour {

	public List<double> aData = new List<double>();
    public List<double> bData = new List<double>();
    public List<double> cData = new List<double>();
    public List<double> dData = new List<double>();
    public List<double> eData = new List<double>();
    public List<double> fData = new List<double>();
    public List<double> gData = new List<double>();
    public List<double> hData = new List<double>();
    public List<double> iData = new List<double>();
    public List<double> jData = new List<double>();
    public List<double> kData = new List<double>();
    public List<double> lData = new List<double>();
    public List<double> mData = new List<double>();
    public List<double> nData = new List<double>();
    public List<double> oData = new List<double>();
    public List<double> pData = new List<double>();
    public List<double> qData = new List<double>();
    public List<double> rData = new List<double>();
    public List<double> sData = new List<double>();
    public List<double> tData = new List<double>();
    public List<double> uData = new List<double>();
    public List<double> vData = new List<double>();
    public List<double> wData = new List<double>();
    public List<double> xData = new List<double>();
    public List<double> yData = new List<double>();
    public List<double> zData = new List<double>();


    //for paragraph
    public string[] paragraph;

    //for Quiz to type Minigame
    public string[] question;
    public string[] choice1;
    public string[] choice2;
    public string[] answer;
    int indexLastQuestion=-1000;
    int dropchance = -1000;

    public double top1 = 0;
    public double top2 = 0;
    public double top3 = 0;

    public string chartop1;
    public string chartop2;
    public string chartop3;

    public double CPM;
    public int WPM;

    public int check = 0; //ถ้าข้อมูลมีตัวอักษร มีมากกว่า 3 จะ +1 ตรงนี้

    public TextAsset vocab;
    public TextAsset vocabHard;

    public List<string> ingameVocabEasy = new List<string>();
    public List<string> ingameVocabHard = new List<string>();

    public List<bool> checkVocabEasy = new List<bool>();
    public List<bool> checkVocabHard = new List<bool>();

    List<string> ingameVocab = new List<string>(); //ไม่ได้ใช้จริง ไว้ใช้เช็คเฉยๆ

    public List<int> WPMcollection = new List<int>();
    List<string> Weaknesscollection = new List<string>();

    private static System.Random rng = new System.Random();

    //here is stupid one
    public int toptop1 = 0;
    public int toptop2 = 0;
    public int toptop3 = 0;

    public string chartoptop1;
    public string chartoptop2;
    public string chartoptop3;
    //end of stupid

    public string[] getParagraph()
    {
        return paragraph;
    }

    public string[] getQuestionAndAns()
    {   
        while(dropchance==indexLastQuestion)
        {
            dropchance = UnityEngine.Random.Range(0, 10);
        }

        indexLastQuestion = dropchance;

        string[] set = new string[4];
        set[0] = question[dropchance];
        set[1] = answer[dropchance];
        set[2] = choice1[dropchance];
        set[3] = choice2[dropchance];

        return set;

    }

    public void sendTimeData(char yaha, double time)
    {
        string letter = ""+yaha;

        if(letter.Equals("a"))
        {
            aData.Add(time);
        }
        else if (letter.Equals("b"))
        {
            bData.Add(time);
        }
        else if (letter.Equals("c"))
        {
            cData.Add(time);
        }
        else if (letter.Equals("d"))
        {
            dData.Add(time);
        }
        else if (letter.Equals("e"))
        {
            eData.Add(time);
        }
        else if (letter.Equals("f"))
        {
            fData.Add(time);
        }
        else if (letter.Equals("g"))
        {
            gData.Add(time);
        }
        else if (letter.Equals("h"))
        {
            hData.Add(time);
        }
        else if (letter.Equals("i"))
        {
            iData.Add(time);
        }
        else if (letter.Equals("j"))
        {
            jData.Add(time);
        }
        else if (letter.Equals("k"))
        {
            kData.Add(time);
        }
        else if (letter.Equals("l"))
        {
            lData.Add(time);
        }
        else if (letter.Equals("m"))
        {
            mData.Add(time);
        }
        else if (letter.Equals("n"))
        {
            nData.Add(time);
        }
        else if (letter.Equals("o"))
        {
            oData.Add(time);
        }
        else if (letter.Equals("p"))
        {
            pData.Add(time);
        }
        else if (letter.Equals("q"))
        {
            qData.Add(time);
        }
        else if (letter.Equals("r"))
        {
            rData.Add(time);
        }
        else if (letter.Equals("s"))
        {
            sData.Add(time);
        }
        else if (letter.Equals("t"))
        {
            tData.Add(time);
        }
        else if (letter.Equals("u"))
        {
            uData.Add(time);
        }
        else if (letter.Equals("v"))
        {
            vData.Add(time);
        }
        else if (letter.Equals("w"))
        {
            wData.Add(time);
        }
        else if (letter.Equals("x"))
        {
            xData.Add(time);
        }
        else if (letter.Equals("y"))
        {
            yData.Add(time);
        }
        else if (letter.Equals("z"))
        {
            zData.Add(time);
        }

    }

    public string sendText(int wordLength, int wordDifficulty)
    {
        List<int> number = new List<int>();

        if (wordDifficulty == 0)
        {
            for (int i = 0; i < ingameVocabEasy.Count; i++) //ตรงนี้จะได้ออกมาละว่ามี index อะไรบ้าง
            {
                number.Add(i);
                
            }
            shuffle(number);
            //เพื่อการดึงแบบ Random อย่างเริ่ด

            for(int i = 0; i<number.Count;i++)
            {
                if(ingameVocabEasy[number[i]].Length == wordLength && checkVocabEasy[number[i]]==false)
                {
                    checkVocabEasy[number[i]] = true;
                    return ingameVocabEasy[number[i]];
                }
            }

            //Debug.Log("mang ma dai pow wa 55555555");

            for(int i =0; i<number.Count;i++)
            {
                if(checkVocabEasy[number[i]]==false)
                {
                    checkVocabEasy[number[i]] = true;
                    return ingameVocabEasy[number[i]];
                }
            }

            return "ERRRRRRORRRRR";
        }

        else if(wordDifficulty == 1)
        {
            for (int i = 0; i < ingameVocabHard.Count; i++) //ตรงนี้จะได้ออกมาละว่ามี index อะไรบ้าง
            {
                number.Add(i);
                
            }
            shuffle(number);
            //เพื่อการดึงแบบ Random อย่างเริ่ด

            for (int i = 0; i < number.Count; i++)
            {
                if (ingameVocabHard[number[i]].Length == wordLength && checkVocabHard[number[i]] == false)
                {
                    checkVocabHard[number[i]] = true;
                    return ingameVocabHard[number[i]];
                }
            }

            //Debug.Log("mang ma dai pow wa 55555555");

            for (int i = 0; i < number.Count; i++)
            {
                if (checkVocabHard[number[i]] == false)
                {
                    checkVocabHard[number[i]] = true;
                    return ingameVocabHard[number[i]];
                }
            }

            return "ERRORRRRR";

        }
        else
        {
            return "ERORRRRRRRRRRRRRR";
        }
        
    }

    public void returnText(string text, int wordDifficulty)
    {
        if(wordDifficulty == 0)
        {
            int i = 0;
            int count = 0;

            for(; i<ingameVocabEasy.Count;i++)
            {
                if(text.Equals(ingameVocabEasy[i]))
                {
                    count = 5;
                    break;
                }
            }

            if(count == 5)
            {
                //Debug.Log("Return is Done");
                checkVocabEasy[i] = false;
            }
            else
            {
                
                //Debug.Log("ERRORRRRR2");
            }
        }
        else if(wordDifficulty == 1)
        {
            int j = 0;
            int count2 = 0;

            for (; j < ingameVocabHard.Count; j++)
            {
                if (text.Equals(ingameVocabHard[j]))
                {
                    count2 = 5;
                    break;
                }
            }

            if(count2==5)
            {
                //Debug.Log("Return is Done");
                checkVocabHard[j] = false;
            }
            else
            {
                //Debug.Log("ERRORRRRR2");
            }
            

        }

    }

    public void shuffle(List<int> yahoo) //Fisher Yates !!! ไว้ดึงศัพท์เนอะ
    {
        int n = yahoo.Count;
        while(n>1)
        {
            n--;
            int k = rng.Next(n + 1);
            int temp = yahoo[k];
            yahoo[k] = yahoo[n];
            yahoo[n] = temp;
        }

    }

    void Awake()
    {
        chartop1 = "a";
        chartop2 = "b";
        chartop3 = "c";
        getVocab(vocab, ingameVocabEasy, checkVocabEasy);
        getVocab(vocabHard, ingameVocabHard, checkVocabHard);
        chartop1 = "";
        chartop2 = "";
        chartop3 = "";



    }
    //เวลาจริงไม่ได้ใช้ Start นะเออ
    void Start () {
        
		DontDestroyOnLoad (transform.gameObject);

        GameObject a = GameObject.Find("New Text");
        string b = "yaha \n yeehawwwwwwwwwww";
        a.GetComponent<TextMesh>().text = b  ;

        //Debug.Log(Game_Controller.a.getParagraph());

        //checkLength(vocab);       //ไว้ดูว่ามีคำศัพท์ยาวเท่าไหร่บ้าง
        //checkLength(vocabHard);

        //checkCount(vocab);        //Combination นี้เป็นยังไง
        //checkCount(vocabHard);

        //getVocab(vocab);
        //getVocab(vocabHard);
        /*
        int i = 10;
      

        while(i>0)
        {
            string[] set = Game_Controller.a.getQuestionAndAns();
            Debug.Log("YAGA" + set[0]);
            Debug.Log(set[1]);
            Debug.Log(set[2]);
            Debug.Log(set[3]);
            i--;
        }
        */




    }

    public void Analysis()
    {
        //ตรงนี้เราขอแค่ว่าในข้อมูลที่เก็บมานะ ตัวอักษร อ่ะ ขอมีแค่ 3 ตัวอักษรที่มีข้อมูลมากกว่า 3 เราจะเริ่มทำทันที เพราะมันจะได้ 3 ตัวอักษรที่อ่อนแอ 555
        
        computeCheck(aData);
        computeCheck(bData);
        computeCheck(cData);
        computeCheck(dData);
        computeCheck(eData);
        computeCheck(fData);
        computeCheck(gData);
        computeCheck(hData);
        computeCheck(iData);
        computeCheck(jData);
        computeCheck(kData);
        computeCheck(lData);
        computeCheck(mData);
        computeCheck(nData);
        computeCheck(oData);
        computeCheck(pData);
        computeCheck(qData);
        computeCheck(rData);
        computeCheck(sData);
        computeCheck(tData);
        computeCheck(uData);
        computeCheck(vData);
        computeCheck(wData);
        computeCheck(xData);
        computeCheck(yData);
        computeCheck(zData);

        //ตรงนี้มันจะ Jenk ไม่พอมันจะเทียบให้เลยด้วยว่ามีตัวอักษรอะไรบ้างที่มีปัญหา
        if(check>=3)
        {

            //Debug.Log("Begin get the new Vocab!!!");
        
            compareTop3(jenkNatBreak(aData), "a");
            compareTop3(jenkNatBreak(bData), "b");
            compareTop3(jenkNatBreak(cData), "c");
            compareTop3(jenkNatBreak(dData), "d");
            compareTop3(jenkNatBreak(eData), "e");
            compareTop3(jenkNatBreak(fData), "f");
            compareTop3(jenkNatBreak(gData), "g");
            compareTop3(jenkNatBreak(hData), "h");
            compareTop3(jenkNatBreak(iData), "i");
            compareTop3(jenkNatBreak(jData), "j");
            compareTop3(jenkNatBreak(kData), "k");
            compareTop3(jenkNatBreak(lData), "l");
            compareTop3(jenkNatBreak(mData), "m");
            compareTop3(jenkNatBreak(nData), "n");
            compareTop3(jenkNatBreak(oData), "o");
            compareTop3(jenkNatBreak(pData), "p");
            compareTop3(jenkNatBreak(qData), "q");
            compareTop3(jenkNatBreak(rData), "r");
            compareTop3(jenkNatBreak(sData), "s");
            compareTop3(jenkNatBreak(tData), "t");
            compareTop3(jenkNatBreak(uData), "u");
            compareTop3(jenkNatBreak(vData), "v");
            compareTop3(jenkNatBreak(wData), "w");
            compareTop3(jenkNatBreak(xData), "x");
            compareTop3(jenkNatBreak(yData), "y");
            compareTop3(jenkNatBreak(zData), "z");
        
            //Debug.Log("Top1 mean is: " + top1);
            //Debug.Log("Top2 mean is: " + top2);
            //Debug.Log("Top3 mean is: " + top3);

            //Debug.Log("Char1 mean is: " + chartop1);
            //Debug.Log("Char2 mean is: " + chartop2);
            //Debug.Log("Char3 mean is: " + chartop3);

            //Debug.Log("Before Count Easy Vocab: " + ingameVocabEasy.Count);
            //Debug.Log("Before Count Hard Vocab: " + ingameVocabHard.Count);

            ingameVocabEasy.Clear();
            ingameVocabHard.Clear();
            checkVocabEasy.Clear();
            checkVocabHard.Clear();

            //เลือกคำศัพท์ที่ตรงกับจุดอ่อนนะจ้ะ แยกออกเป็น Easy และ Hard นะจ้ะ
            getVocab(vocab, ingameVocabEasy, checkVocabEasy);
            getVocab(vocabHard, ingameVocabHard, checkVocabHard);

            //Debug.Log("Get the new Vocab!!!");
            //Debug.Log("New Count Easy Vocab: " + ingameVocabEasy.Count);
            //Debug.Log("New Count Hard Vocab: " + ingameVocabHard.Count);

            //ใช้ค่า Mean เยอะสุดของตัวอักษร ในการหาว่า WPM เค้าเท่าไหร่ มันจะเป็นอะไรที่ช้าที่สุดสำหรับเค้า
            CPM = Math.Round(60.0 / top1);
            WPM = (int)Math.Round(CPM / 5);
            //Debug.Log("CPM is: " + CPM);
            //Debug.Log("WPM is: " + WPM);

            //แถวๆนี้ต้องมีกระบวนการเซฟ เก็บไว้ในนี้ แล้วจะมี Method คำนวณทุกอย่างตอนผู้เล่นนออกเกมจ้า...แล้วเก็บข้อมูลชุดนั้นไว้ใน Player เลย
            //ต้องการ WPM กับ ตัวอักษรสุดกาก
            WPMcollection.Add(WPM);
            Weaknesscollection.Add(chartop1);
            Weaknesscollection.Add(chartop2);
            Weaknesscollection.Add(chartop3);



            chartop1 = null;
            chartop2 = null;
            chartop3 = null;
            chartoptop1 = null;
            chartoptop2 = null;
            chartoptop3 = null;
            top1 = 0;
            top2 = 0;
            top3 = 0;
            toptop1 = 0;
            toptop2 = 0;
            toptop3 = 0;

            CPM = 0;
            WPM = 0;

            check = 0;

        aData.Clear();
        bData.Clear();
        cData.Clear();
        dData.Clear();
        eData.Clear();
        fData.Clear();
        gData.Clear();
        hData.Clear();
        iData.Clear();
        jData.Clear();
        kData.Clear();
        lData.Clear();
        mData.Clear();
        nData.Clear();
        oData.Clear();
        pData.Clear();
        qData.Clear();
        rData.Clear();
        sData.Clear();
        tData.Clear();
        uData.Clear();
        vData.Clear();
        wData.Clear();
        xData.Clear();
        yData.Clear();
        zData.Clear();
        
        }
        else
        {
            //Debug.Log("No Analysis na ja !!!");
            //Debug.Log("Count of vocab Easy: " + ingameVocabEasy.Count);
            //Debug.Log("Count of vocab Hard: " + ingameVocabHard.Count);
            clearAllVocab();
        } 
        
    }

    public void clearAllVocab() //Clear all check word
    {
        for(int i = 0;i<checkVocabEasy.Count;i++)
        {
            checkVocabEasy[i] = false;
        }
        for(int i = 0;i<checkVocabHard.Count;i++)
        {
            checkVocabHard[i] = false;
        }
    }

    public void getVocab(TextAsset vocab, List<string> ingameVocab, List<bool> checkVocab)
    {
        string a = vocab.text;
        string[] lines = a.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Contains(chartop1) || lines[i].Contains(chartop2) || lines[i].Contains(chartop3) || lines[i].Length==1)
            {
                ingameVocab.Add(lines[i]);
                checkVocab.Add(false);
            }
        }
    }

    //ไว้เรียกตอนออกจากเกม ไรพวกนี้อ่ะ กับตอนที่ New Game วัด Word's Diff ครั้งแรก
    public int computeWPM()
    {
        int result = 0;
        for(int i = 0; i<WPMcollection.Count;i++)
        {
            result += WPMcollection[i];
        }

        int x = WPMcollection.Count;
        WPMcollection.Clear();
        chartop1 = null;
        chartop2 = null;
        chartop3 = null;
        chartoptop1 = null;
        chartoptop2 = null;
        chartoptop3 = null;
        top1 = 0;
        top2 = 0;
        top3 = 0;
        toptop1 = 0;
        toptop2 = 0;
        toptop3 = 0;
        if(x==0)
        {
            return 0;
        }
        else
        {
            return result / x;
        }

       
    }
    
    public string computeWeakness()
    {

        string weakness="";
        

        comparestupid(stupid("a"), "a");
        comparestupid(stupid("b"), "b");
        comparestupid(stupid("c"), "c");
        comparestupid(stupid("d"), "d");
        comparestupid(stupid("e"), "e");
        comparestupid(stupid("f"), "f");
        comparestupid(stupid("g"), "g");
        comparestupid(stupid("h"), "h");
        comparestupid(stupid("i"), "i");
        comparestupid(stupid("j"), "j");
        comparestupid(stupid("k"), "k");
        comparestupid(stupid("l"), "l");
        comparestupid(stupid("m"), "m");
        comparestupid(stupid("n"), "n");
        comparestupid(stupid("o"), "o");
        comparestupid(stupid("p"), "p");
        comparestupid(stupid("q"), "q");
        comparestupid(stupid("r"), "r");
        comparestupid(stupid("s"), "s");
        comparestupid(stupid("t"), "t");
        comparestupid(stupid("u"), "u");
        comparestupid(stupid("v"), "v");
        comparestupid(stupid("w"), "w");
        comparestupid(stupid("x"), "x");
        comparestupid(stupid("y"), "y");
        comparestupid(stupid("z"), "z");

        weakness += chartoptop1;
        weakness += chartoptop2;
        weakness += chartoptop3;

        chartop1 = null;
        chartop2 = null;
        chartop3 = null;
        chartoptop1 = null;
        chartoptop2 = null;
        chartoptop3 = null;
        top1 = 0;
        top2 = 0;
        top3 = 0;
        toptop1 = 0;
        toptop2 = 0;
        toptop3 = 0;

        Weaknesscollection.Clear();

        return weakness;
    }

    public int stupid(string a)
    {
        int temp = 0;
        for(int i = 0;i<Weaknesscollection.Count;i++)
        {
            if(Weaknesscollection[i].Equals(a))
            {
                temp++;
            }
        }
        return temp;
    }

    public void comparestupid(int mean, string b)
    {
        int meantemp = 0;
        string strtemp = "";

        int meantemp2 = 0;
        string strtemp2 = "";

        if (mean > toptop1)
        {
            meantemp = toptop1;
            strtemp = chartoptop1;

            toptop1 = mean;
            chartoptop1 = b;

            if (meantemp > toptop2)
            {
                meantemp2 = toptop2;
                strtemp2 = chartoptop2;

                toptop2 = meantemp;
                chartoptop2 = strtemp;

                if (meantemp2 > toptop3)
                {
                    toptop3 = meantemp2;
                    chartoptop3 = strtemp2;
                }
            }
            else if (meantemp > toptop3)
            {
                toptop3 = meantemp;
                chartoptop3 = strtemp;
            }
        }
        else if (mean > toptop2)
        {
            meantemp = toptop2;
            strtemp = chartoptop2;

            toptop2 = mean;
            chartoptop2 = b;

            if (meantemp > toptop3)
            {
                toptop3 = meantemp;
                chartoptop3 = strtemp;
            }
        }
        else if (mean > toptop3)
        {
            toptop3 = mean;
            chartoptop3 = b;
        }

    }

    public int computeWordDiff(int WPM)
    {
        
        if(WPM >= 110)
        {
            return 4;
        }
        else if(WPM >=81)
        {
            return 3;
        }
        else if(WPM >= 51)
        {
            return 2;
        }
        else if(WPM >= 21)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
    
    
    void computeCheck(List<double> data)
    {
        if(data.Count>=3)
        {
            check++;
        }
    }

    void compareTop3(double mean, string letter)
    {
        double meantemp = 0;
        string strtemp = "";

        double meantemp2 = 0;
        string strtemp2 = "";

        if (mean > top1)
        {
            meantemp = top1;
            strtemp = chartop1;

            top1 = mean;
            chartop1 = letter;

            if(meantemp > top2)
            {
                meantemp2 = top2;
                strtemp2 = chartop2;

                top2 = meantemp;
                chartop2 = strtemp;

                if(meantemp2 > top3)
                {
                    top3 = meantemp2;
                    chartop3 = strtemp2;
                }
            }
            else if(meantemp > top3)
            {
                top3 = meantemp;
                chartop3 = strtemp;
            }
        }
        else if (mean > top2)
        {
            meantemp = top2;
            strtemp = chartop2;

            top2 = mean;
            chartop2 = letter;

            if(meantemp > top3)
            {
                top3 = meantemp;
                chartop3 = strtemp;
            }
        }
        else if (mean > top3)
        {
            top3 = mean;
            chartop3 = letter;
        }
    }

    double jenkNatBreak(List<double> data)
    {
        double result1 = 0;
        double result2 = 0;
        double result3 = 0;

        double mean1 = 0;
        double mean2 = 0;
        double mean3 = 0;

        double total = 0;

        double count = 0;

        double compare = 10000;


        double sep1 = 0;
        double sep2 = 0;

        //ข้อมูลต้องมีมากกว่า 3 ถึงจะเริ่มทำงาน
        if (data.Count >= 3)
        {

            data.Sort();

            //แยกความน่าจะเป็นทั้งหมดที่เป็นไปได้ โดยใช้ไม้กั้น 5 Data 2 ไม้กั้น 4C2 = 6 แบบ
            for (int i = 0; i < data.Count - 2; i++) //ยังไม่ชัวเลยว่าถูกป่าว 5555555
            {
                for (int j = i + 1; j < data.Count - 1; j++)
                {
                    int ii = 0;
                    int jj = i + 1;
                    int kk = j + 1;

                    while (ii <= i) //นับว่า Cluster1 มีกี่ตัว รวมค่าด้วย
                    {
                        result1 = data[ii] + result1;
                        ii++;
                        count++;
                    }

                    mean1 = result1 / count;
                    count = 0;
                    ii = 0;
                    ////Debug.Log("mean1 is: " + mean1 + " for the I value: " + i + " and J value: " + j); //ค่า Mean ถูกแล้วนะจ้ะ

                    while (ii <= i) //เริ่มหา SDCAM
                    {
                        ////Debug.Log("Pow: " + Math.Pow(data[ii] - mean1, 2) + " for the I value: " + i + " and J value: " + j + " value of ii: " + ii);
                        total = total + Math.Pow(data[ii] - mean1, 2);
                        ii++;
                    }

                    while (jj <= j) //นับว่า Cluster2 มีกี่ตัว รวมค่าด้วย
                    {
                        result2 = data[jj] + result2;
                        jj++;
                        count++;
                    }

                    mean2 = result2 / count;
                    count = 0;
                    jj = i + 1;
                    ////Debug.Log("mean2 is: " + mean2 + " for the I value: " + i + " and J value: " + j);

                    while (jj <= j) //เริ่มหา SDCAM
                    {
                        ////Debug.Log("Pow: " + Math.Pow(data[jj] - mean2, 2) + " for the I value: " + i + " and J value: " + j + " value of jj: " + jj);
                        total = total + Math.Pow(data[jj] - mean2, 2);
                        jj++;
                    }

                    while (kk <= data.Count - 1) //นับว่า Cluster3 มีกี่ตัว รวมค่าด้วย
                    {
                        result3 = data[kk] + result3;
                        kk++;
                        count++;
                    }

                    mean3 = result3 / count;
                    count = 0;
                    kk = j + 1;
                    ////Debug.Log("mean3 is: " + mean3 + " for the I value: " + i + " and J value: " + j);

                    while (kk <= data.Count - 1) //เริ่มหา SDCAM
                    {
                        ////Debug.Log("Pow: " + Math.Pow(data[kk] - mean3, 2) + " for the I value: " + i + " and J value: " + j + " value of kk: " + kk);
                        total = total + Math.Pow(data[kk] - mean3, 2);
                        kk++;
                    }

                    ////Debug.Log("Total is: " + total + " for the I value: " + i + " and J value: " + j);

                    if (total < compare)
                    {
                        compare = total;
                        sep1 = i;
                        sep2 = j;
                    }

                    ////Debug.Log("//////////End of this possibility////////" + i + j);


                    result1 = 0;
                    result2 = 0;
                    result3 = 0;

                    total = 0;

                }
            }

            ////Debug.Log(compare);
            ////Debug.Log("Sep1 is at: " + sep1);
            ////Debug.Log("Sep2 is at: " + sep2);

            double yaha = 0;
            int count2 = 0;


            

            for (int iii = 0; iii <= sep2; iii++)
            {
                yaha = data[iii] + yaha;
                count2++;
            }

            ////Debug.Log("Remove the third cluster the result is: " + yaha);
            ////Debug.Log("Mean is: " + (yaha / count2));

            return yaha / count2;

        }

        else
        {
            return 0;
        }
    }

    public void checkLength(TextAsset vocab) //ไว้ดูว่าในคลังนี้ มีศัพท์ความยาวเท่านี้ เป็นจำนวนเท่าไหร่
    {
        string a = vocab.text;
        string[] lines = a.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

        for (int i = 0; i < lines.Length; i++)
        {
            //Debug.Log("Length is: " + lines[i].Length);
        }
    }


    public void checkCount(TextAsset vocab) //ไว้ดูว่า พอดึง 3 ตัวอักษรชุดนี้นะ ในคลังศัพท์นี้นะ จะมีศัพท์ถูกเลือกมาทั้งหมดเท่าไหร่
    {
        string a = vocab.text;
        string[] lines = a.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

        List<string> alphabet = new List<string>();
        alphabet.Add("a");
        alphabet.Add("b");
        alphabet.Add("c");
        alphabet.Add("d");
        alphabet.Add("e");
        alphabet.Add("f");
        alphabet.Add("g");
        alphabet.Add("h");
        alphabet.Add("i");
        alphabet.Add("j");
        alphabet.Add("k");
        alphabet.Add("l");
        alphabet.Add("m");
        alphabet.Add("n");
        alphabet.Add("o");
        alphabet.Add("p");
        alphabet.Add("q");
        alphabet.Add("r");
        alphabet.Add("s");
        alphabet.Add("t");
        alphabet.Add("u");
        alphabet.Add("v");
        alphabet.Add("w");
        alphabet.Add("x");
        alphabet.Add("y");
        alphabet.Add("z");

        for (int i = 0; i < alphabet.Count - 2; i++)
        {
            for (int j = i + 1; j < alphabet.Count - 1; j++)
            {
                for (int k = j + 1; k < alphabet.Count; k++)
                {
                    for (int ii = 0; ii < lines.Length; ii++)
                    {
                        if (lines[ii].Contains(alphabet[i]) || lines[ii].Contains(alphabet[j]) || lines[ii].Contains(alphabet[k]))
                        {
                            ingameVocab.Add(lines[ii]);
                        }
                    }

                    if (ingameVocab.Count < 100) //ถ้าเกิดว่า 3 ตัวที่เลือกเนี่ย มีศัพท์น้อยกว่า 100 ให้โชว์ออกมา ^_^
                    {
                        //Debug.Log("For Letter: " + alphabet[i] + " " + alphabet[j] + " " + alphabet[k] + " = " + ingameVocab.Count);

                        /*
                        for (int y = 0; y < ingameVocab.Count; y++)
                        {
                            //Debug.Log(i + " " + j + " " + k + " " + ingameVocab[y]);
                        }
                        */

                        ingameVocab.Clear();
                    }
                    else
                    {
                        ingameVocab.Clear();
                    }
                }
            }
        }
    }


}
