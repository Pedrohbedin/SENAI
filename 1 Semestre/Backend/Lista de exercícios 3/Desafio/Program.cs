int numeroAnterior = 0;
int numeroAtual = 1;
int novoNumero;
int fibonacci;

   
for (int i = 0; i <500;  i++){  

       fibonacci = numeroAnterior + numeroAtual; 
       Console.WriteLine  (fibonacci);
       numeroAnterior = numeroAtual; 
       numeroAtual = fibonacci;   
  }
  
    
