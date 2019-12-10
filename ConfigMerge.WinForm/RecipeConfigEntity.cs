using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConfigMerge.WinForm
{
    public class RecipeConfigEntity : INotifyPropertyChanged
    {
        private Guid _id;
        public Guid Id { get => _id;set { _id = value; SendChangeInfo("Id"); } }
        [StringLength(256)]
        [Required()]
        public string OutputConfigFile { get => mOutputConfigFile; set { mOutputConfigFile = value; SendChangeInfo("OutputConfigFile"); } }

        [StringLength(256)]
        [Required()]
        public string InputConfigFolder { get => inputConfigFolder; set { inputConfigFolder = value; SendChangeInfo("InputConfigFolder"); } }
        private string mOutputConfigFile;
        private string inputConfigFolder;

        [StringLength(50)]
        [Required()]
        public string Name { get => mName; set { mName = value; SendChangeInfo("Name"); } }
        [StringLength(20)]
        [Required()]
        public string Classify { get => classify; set { classify = value; SendChangeInfo("Classify"); } }
        private string mName;
        private string classify;
        /// <summary>
        /// 属性改变后需要调用的方法，触发PropertyChanged事件。
        /// </summary>
        /// <param name="propertyName">属性名</param>
        private void SendChangeInfo(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
