// Задача 73 : Есть число N. Сколько групп M, можно получить при разбиении всех чисел на группы, так чтобы в одной группе 
// все числа были взаимно просты (все числа в группе друг на друга не делятся)? 
// Найдите M при заданном N и получите одно из разбиений на группы N ≤ 10²⁰.

// Например, для N = 50, M получается 6

// Группа 1: 1
// Группа 2: 2 3 11 13 17 19 23 29 31 37 41 43 47
// Группа 3: 4 6 9 10 14 15 21 22 25 26 33 34 35 38 39 46 49
// Группа 4: 8 12 18 20 27 28 30 42 44 45 50
// Группа 5: 7 16 24 36 40
// Группа 6: 5 32 48

// Группа 1: 1
// Группа 2: 2 3 5 7 11 13 17 19 23 29 31 37 41 43 47
// Группа 3: 4 6 9 10 14 15 21 22 25 26 33 34 35 38 39 46 49
// Группа 4: 8 12 18 20 27 28 30 42 44 45 50
// Группа 5: 16 24 36 40
// Группа 6: 32 48

int nn = (int) Math.Pow(10,5);
int[] groups = new int[nn + 1];
int max_group = 1;

groups[1] = 1;
for (int i = 2; i < groups.Length; i++)
{
    Console.WriteLine(i);
    int grp = 1;
    while (!IsGroup(grp, i))
    {
        grp++;
    }
    groups[i] = grp;
    if (grp > max_group)
        max_group = grp;
}
PrintGroups();

bool IsGroup(int group, int ii) // проверяет, может ли ii войти в текущую группу взаимно неделимых чисел
{
    for (int i = 1; i < ii; i++)
    {
        if (groups[i] == group && ii % i == 0)
            return false;
    }
    return true;
}

void PrintGroups()
{
    for (int ii = 1; ii <= max_group; ii++)
    {
        Console.Write($"Группа {ii}: ");
        for (int jj = 1; jj < groups.Length; jj++)
        {
            if (groups[jj] == ii)
                Console.Write($"{jj} ");
        }
        Console.WriteLine();
    }
}