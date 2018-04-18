using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BindableInfrastructure
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ClassHierarchyPage : ContentPage
	{
		public ClassHierarchyPage ()
		{
			InitializeComponent ();
            List<TypeInformation> classList = new List<TypeInformation>();

            GetPublicTypes(typeof(View).GetTypeInfo().Assembly, classList);
            GetPublicTypes(typeof(Extensions).GetTypeInfo().Assembly, classList);
            int index = 0;

            do
            {
                TypeInformation childType = classList[index];
                if (childType.Type != typeof(Object))
                {
                    bool hasBaseType = false;

                    foreach (TypeInformation parentType in classList)
                    {
                        if (childType.IsDerivedDirectlyFrom(parentType.Type))
                        {
                            hasBaseType = true;
                        }
                    }

                    if (!hasBaseType && childType.BaseType != typeof(Object))
                    {
                        classList.Add(new TypeInformation(childType.BaseType, false));
                    }
                }
                index++;
            }
            while (index < classList.Count);

            classList.Sort((t1, t2) => {
                return String.Compare(t1.Type.Name, t2.Type.Name);
            });

            ClassAndSubclasses rootClass = new ClassAndSubclasses(typeof(Object), false);
            AddChildrenToParent(rootClass, classList);
            AddItemToStackLayout(rootClass, 0);
            
		}

        void GetPublicTypes(Assembly assembly, List<TypeInformation> classList)
        {
            foreach(Type type in assembly.ExportedTypes)
            {
                TypeInfo typeInfo = type.GetTypeInfo();
                if(typeInfo.IsPublic && !typeInfo.IsInterface)
                {
                    classList.Add(new TypeInformation(type, true));
                }
            }
        }

        void AddChildrenToParent(ClassAndSubclasses parentClass, List<TypeInformation> classList)
        {
            foreach(TypeInformation typeInformation in classList)
            {
                if(typeInformation.IsDerivedDirectlyFrom(parentClass.Type))
                {
                    ClassAndSubclasses subClass = new ClassAndSubclasses(typeInformation.Type, typeInformation.IsXamarinForms);
                    parentClass.Subclasses.Add(subClass);
                    AddChildrenToParent(subClass, classList);
                }
            }
        }

        void AddItemToStackLayout(ClassAndSubclasses parentClass, int level)
        {
            string name = parentClass.IsXamarinForms ? parentClass.Type.Name : parentClass.Type.FullName;
            TypeInfo typeInfo = parentClass.Type.GetTypeInfo();

            if(typeInfo.IsGenericType)
            {
                Type[] parameters = typeInfo.GenericTypeParameters;
                name = name.Substring(0, name.Length - 2);
                name += "<";

                for(int i=0;i<parameters.Length;i++)
                {
                    name += parameters[i].Name;
                    if(i < parameters.Length - 1)
                    {
                        name += ", ";
                    }
                }
                name += ">";
            }

            Label label = new Label
            {
                Text = String.Format("{0}{1}", new string(' ', 4 * level), name),
                TextColor = parentClass.Type.GetTypeInfo().IsAbstract ? Color.Accent : Color.Default
            };

            stackLayout.Children.Add(label);

            foreach(ClassAndSubclasses subClass in parentClass.Subclasses)
            {
                AddItemToStackLayout(subClass, level + 1);
            }
        }
	}
}