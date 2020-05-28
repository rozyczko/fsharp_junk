let rnd = new System.Random()
let a = Array2D.init 200 200 (fun _ _ -> rnd.NextDouble())
let b = Array2D.init 200 200 (fun _ _ -> rnd.NextDouble())
;;

//==================================================================
let matrixMultiplyWithAsync (a:float[,]) (b:float[,]) =
    let rowsA, colsA = Array2D.length1 a, Array2D.length2 a
    let rowsB, colsB = Array2D.length1 b, Array2D.length2 b
    let result = Array2D.create rowsA colsB 0.0
    [ for i in 0 .. rowsA - 1 ->
        async {
           for j in 0 .. colsB - 1 do
             for k in 0 .. colsA - 1 do
               result.[i,j] <- result.[i,j] + a.[i,k] * b.[k,j]
        } ]
    |> Async.Parallel
    |> Async.RunSynchronously
    |> ignore
    result;;
//val matrixMultiplyWithAsync : float [,] -> float [,] -> float [,]

//==================================================================
open System.Threading.Tasks
let matrixMultiplyWithTasks (a:float[,]) (b:float[,]) =
    let rowsA, colsA = Array2D.length1 a, Array2D.length2 a
    let rowsB, colsB = Array2D.length1 b, Array2D.length2 b
    let result = Array2D.create rowsA colsB 0.0
    Parallel.For(0, rowsA, (fun i->
        for j = 0 to colsB - 1 do
           for k = 0 to colsA - 1 do
              result.[i,j] <- result.[i,j] + a.[i,k] * b.[k,j]))  
    |> ignore
    result;;
//val matrixMultiplyWithTasks : float [,] -> float [,] -> float [,]

//==================================================================
// Using Parallel Sequences
//
// PSeq.iter takes the input as a list (instead of a range) so
// we use a simple comprehension to generate a list of indices
open Microsoft.FSharp.Collections
let matrixMultiplyWithPSeq (a:float[,]) (b:float[,]) =
    let rowsA, colsA = Array2D.length1 a, Array2D.length2 a
    let rowsB, colsB = Array2D.length1 b, Array2D.length2 b
    let result = Array2D.create rowsA colsB 0.0
    [ 0 .. rowsA - 1 ] |> PSeq.iter (fun i ->
      for j = 0 to colsB - 1 do
        for k = 0 to colsA - 1 do
          result.[i,j] <- result.[i,j] + a.[i,k] * b.[k,j] )
    result;;
//val matrixMultiplyWithPSeq : float [,] -> float [,] -> float [,]


//==================================================================
// Let's test the calls

let stopWatch = System.Diagnostics.Stopwatch.StartNew()
matrixMultiplyWithAsync a b;;
stopWatch.Stop()
printfn "%f" stopWatch.Elapsed.TotalMilliseconds

matrixMultiplyWithTasks a b;;

matrixMultiplyWithPSeq a b;;

