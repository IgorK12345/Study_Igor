<a name='assembly'></a>
# Study.LabWork1

## Contents

- [Complex](#T-Study-LabWork1-Features-Task1-Complex 'Study.LabWork1.Features.Task1.Complex')
  - [#ctor()](#M-Study-LabWork1-Features-Task1-Complex-#ctor-System-Double,System-Double- 'Study.LabWork1.Features.Task1.Complex.#ctor(System.Double,System.Double)')
  - [ToString()](#M-Study-LabWork1-Features-Task1-Complex-ToString 'Study.LabWork1.Features.Task1.Complex.ToString')
  - [op_Addition()](#M-Study-LabWork1-Features-Task1-Complex-op_Addition-Study-LabWork1-Features-Task1-Complex,Study-LabWork1-Features-Task1-Complex- 'Study.LabWork1.Features.Task1.Complex.op_Addition(Study.LabWork1.Features.Task1.Complex,Study.LabWork1.Features.Task1.Complex)')
  - [op_Division()](#M-Study-LabWork1-Features-Task1-Complex-op_Division-Study-LabWork1-Features-Task1-Complex,Study-LabWork1-Features-Task1-Complex- 'Study.LabWork1.Features.Task1.Complex.op_Division(Study.LabWork1.Features.Task1.Complex,Study.LabWork1.Features.Task1.Complex)')
  - [op_Equality()](#M-Study-LabWork1-Features-Task1-Complex-op_Equality-Study-LabWork1-Features-Task1-Complex,Study-LabWork1-Features-Task1-Complex- 'Study.LabWork1.Features.Task1.Complex.op_Equality(Study.LabWork1.Features.Task1.Complex,Study.LabWork1.Features.Task1.Complex)')
  - [op_Inequality()](#M-Study-LabWork1-Features-Task1-Complex-op_Inequality-Study-LabWork1-Features-Task1-Complex,Study-LabWork1-Features-Task1-Complex- 'Study.LabWork1.Features.Task1.Complex.op_Inequality(Study.LabWork1.Features.Task1.Complex,Study.LabWork1.Features.Task1.Complex)')
  - [op_Multiply()](#M-Study-LabWork1-Features-Task1-Complex-op_Multiply-Study-LabWork1-Features-Task1-Complex,Study-LabWork1-Features-Task1-Complex- 'Study.LabWork1.Features.Task1.Complex.op_Multiply(Study.LabWork1.Features.Task1.Complex,Study.LabWork1.Features.Task1.Complex)')
  - [op_Subtraction()](#M-Study-LabWork1-Features-Task1-Complex-op_Subtraction-Study-LabWork1-Features-Task1-Complex,Study-LabWork1-Features-Task1-Complex- 'Study.LabWork1.Features.Task1.Complex.op_Subtraction(Study.LabWork1.Features.Task1.Complex,Study.LabWork1.Features.Task1.Complex)')
  - [op_UnaryNegation(a)](#M-Study-LabWork1-Features-Task1-Complex-op_UnaryNegation-Study-LabWork1-Features-Task1-Complex- 'Study.LabWork1.Features.Task1.Complex.op_UnaryNegation(Study.LabWork1.Features.Task1.Complex)')
  - [op_UnaryPlus(a)](#M-Study-LabWork1-Features-Task1-Complex-op_UnaryPlus-Study-LabWork1-Features-Task1-Complex- 'Study.LabWork1.Features.Task1.Complex.op_UnaryPlus(Study.LabWork1.Features.Task1.Complex)')
- [IRunService](#T-Study-LabWork1-Shared-Abstractions-IRunService 'Study.LabWork1.Shared.Abstractions.IRunService')
  - [RunTask1()](#M-Study-LabWork1-Shared-Abstractions-IRunService-RunTask1 'Study.LabWork1.Shared.Abstractions.IRunService.RunTask1')
  - [RunTask2()](#M-Study-LabWork1-Shared-Abstractions-IRunService-RunTask2 'Study.LabWork1.Shared.Abstractions.IRunService.RunTask2')
  - [RunTask3()](#M-Study-LabWork1-Shared-Abstractions-IRunService-RunTask3 'Study.LabWork1.Shared.Abstractions.IRunService.RunTask3')
- [Program](#T-Study-LabWork1-Program 'Study.LabWork1.Program')
  - [RUN_TASK_NUMBER](#F-Study-LabWork1-Program-RUN_TASK_NUMBER 'Study.LabWork1.Program.RUN_TASK_NUMBER')
  - [Main()](#M-Study-LabWork1-Program-Main 'Study.LabWork1.Program.Main')
- [RunService](#T-Study-LabWork1-Shared-Services-RunService 'Study.LabWork1.Shared.Services.RunService')
  - [RunTask1()](#M-Study-LabWork1-Shared-Services-RunService-RunTask1 'Study.LabWork1.Shared.Services.RunService.RunTask1')
  - [RunTask2()](#M-Study-LabWork1-Shared-Services-RunService-RunTask2 'Study.LabWork1.Shared.Services.RunService.RunTask2')
  - [RunTask3()](#M-Study-LabWork1-Shared-Services-RunService-RunTask3 'Study.LabWork1.Shared.Services.RunService.RunTask3')

<a name='T-Study-LabWork1-Features-Task1-Complex'></a>
## Complex `type`

##### Namespace

Study.LabWork1.Features.Task1

<a name='M-Study-LabWork1-Features-Task1-Complex-#ctor-System-Double,System-Double-'></a>
### #ctor() `constructor`

##### Summary

Конструктор комплексного числа

##### Parameters

This constructor has no parameters.

<a name='M-Study-LabWork1-Features-Task1-Complex-ToString'></a>
### ToString() `method`

##### Summary

Строковое представление комплексного числа
Форматы: "1.01 + 2.00i", "3.00", "4.00i"

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Features-Task1-Complex-op_Addition-Study-LabWork1-Features-Task1-Complex,Study-LabWork1-Features-Task1-Complex-'></a>
### op_Addition() `method`

##### Summary

Сложение комплексных чисел

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Features-Task1-Complex-op_Division-Study-LabWork1-Features-Task1-Complex,Study-LabWork1-Features-Task1-Complex-'></a>
### op_Division() `method`

##### Summary

Деление комплексных чисел: (a+bi)/(c+di) = ((ac+bd)/(c²+d²)) + ((bc-ad)/(c²+d²))i

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Features-Task1-Complex-op_Equality-Study-LabWork1-Features-Task1-Complex,Study-LabWork1-Features-Task1-Complex-'></a>
### op_Equality() `method`

##### Summary

Проверка на равенство двух комплексных чисел

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Features-Task1-Complex-op_Inequality-Study-LabWork1-Features-Task1-Complex,Study-LabWork1-Features-Task1-Complex-'></a>
### op_Inequality() `method`

##### Summary

Проверка на неравенство двух комплексных чисел

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Features-Task1-Complex-op_Multiply-Study-LabWork1-Features-Task1-Complex,Study-LabWork1-Features-Task1-Complex-'></a>
### op_Multiply() `method`

##### Summary

Умножение комплексных чисел: (a+bi)*(c+di) = (ac-bd) + (ad+bc)i

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Features-Task1-Complex-op_Subtraction-Study-LabWork1-Features-Task1-Complex,Study-LabWork1-Features-Task1-Complex-'></a>
### op_Subtraction() `method`

##### Summary

Вычитание комплексных чисел

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Features-Task1-Complex-op_UnaryNegation-Study-LabWork1-Features-Task1-Complex-'></a>
### op_UnaryNegation(a) `method`

##### Summary

Унарный минус - получение сопряженного комплексного числа

##### Returns

Сопряженное комплексное число

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| a | [Study.LabWork1.Features.Task1.Complex](#T-Study-LabWork1-Features-Task1-Complex 'Study.LabWork1.Features.Task1.Complex') | Комплексное число |

<a name='M-Study-LabWork1-Features-Task1-Complex-op_UnaryPlus-Study-LabWork1-Features-Task1-Complex-'></a>
### op_UnaryPlus(a) `method`

##### Summary

Унарный плюс - вычисление модуля комплексного числа

##### Returns

Модуль числа (длина вектора)

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| a | [Study.LabWork1.Features.Task1.Complex](#T-Study-LabWork1-Features-Task1-Complex 'Study.LabWork1.Features.Task1.Complex') | Комплексное число |

<a name='T-Study-LabWork1-Shared-Abstractions-IRunService'></a>
## IRunService `type`

##### Namespace

Study.LabWork1.Shared.Abstractions

##### Summary

Интерфейс для реализации заданий Л/Р

<a name='M-Study-LabWork1-Shared-Abstractions-IRunService-RunTask1'></a>
### RunTask1() `method`

##### Summary

Запуск выполнения задания 1

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Shared-Abstractions-IRunService-RunTask2'></a>
### RunTask2() `method`

##### Summary

Запуск выполнения задания 2

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Shared-Abstractions-IRunService-RunTask3'></a>
### RunTask3() `method`

##### Summary

Запуск выполнения задания 3

##### Parameters

This method has no parameters.

<a name='T-Study-LabWork1-Program'></a>
## Program `type`

##### Namespace

Study.LabWork1

##### Summary

Начальная точка входа

<a name='F-Study-LabWork1-Program-RUN_TASK_NUMBER'></a>
### RUN_TASK_NUMBER `constants`

##### Summary

Номер выполняемой задачи

<a name='M-Study-LabWork1-Program-Main'></a>
### Main() `method`

##### Summary

Старт программы

##### Parameters

This method has no parameters.

<a name='T-Study-LabWork1-Shared-Services-RunService'></a>
## RunService `type`

##### Namespace

Study.LabWork1.Shared.Services

##### Summary

Реализация заданий Л/Р

<a name='M-Study-LabWork1-Shared-Services-RunService-RunTask1'></a>
### RunTask1() `method`

##### Summary

Задание 1 - Комплексные числа

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Shared-Services-RunService-RunTask2'></a>
### RunTask2() `method`

##### Summary

Задание 2

##### Parameters

This method has no parameters.

<a name='M-Study-LabWork1-Shared-Services-RunService-RunTask3'></a>
### RunTask3() `method`

##### Summary

Задание 3

##### Parameters

This method has no parameters.
