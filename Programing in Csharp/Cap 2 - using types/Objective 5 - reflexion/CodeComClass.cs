using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom;
using Microsoft.CSharp;
using System.IO;
using System.CodeDom.Compiler;
using System.Linq.Expressions;

namespace Programing_in_Csharp
{
    class CodeComClass
    {
        public void CreateAHelloWorld()
        {
            CodeCompileUnit compileUnit = new CodeCompileUnit();
            CodeNamespace codeNamespace = new CodeNamespace("XNamespace");
            codeNamespace.Imports.Add(new CodeNamespaceImport("System"));
            CodeTypeDeclaration myclass = new CodeTypeDeclaration("myClass");
            CodeEntryPointMethod start = new CodeEntryPointMethod();
            CodeMethodInvokeExpression cs1 = new CodeMethodInvokeExpression(
                new CodeTypeReferenceExpression("Console"), "WriteLine", new CodePrimitiveExpression("Hello World!"));

            compileUnit.Namespaces.Add(codeNamespace);
            codeNamespace.Types.Add(myclass);
            myclass.Members.Add(start);
            start.Statements.Add(cs1);

            //create a source file
            CSharpCodeProvider provider = new CSharpCodeProvider();
            using (StreamWriter sw = new StreamWriter("helloworld.cs", false)) {
                IndentedTextWriter tw = new IndentedTextWriter(sw, " ");
                provider.GenerateCodeFromCompileUnit(compileUnit, tw, new CodeGeneratorOptions());
                tw.Close();
            }



        }


        public void UseLambda() {
            Func<int, int, int> addFunc = (x, y) => x + y;
            Console.WriteLine(addFunc(1, 2));
        }


        public void ExpressionTree() {
            BlockExpression block = Expression.Block(
                Expression.Call(
                    null,
                    typeof(Console).GetMethod("Write", new Type[] { typeof(string) }),
                    Expression.Constant("hello ")), 
                    Expression.Call(
                        null,
                        typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }),
                        Expression.Constant("World!")
                        )
                    );


            Expression.Lambda<Action>(block).Compile()();

        }
    }
}
