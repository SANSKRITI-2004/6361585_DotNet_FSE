using System;
using System.Windows.Forms;
using Confluent.Kafka;

namespace KafkaWinFormChat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            

            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };

            using var producer = new ProducerBuilder<Null, string>(config).Build();

            string message = textBox1.Text;

            if (!string.IsNullOrWhiteSpace(message))
            {
                await producer.ProduceAsync("chat-topic", new Message<Null, string> { Value = message });
                MessageBox.Show("Message sent to Kafka!");
                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a message.");
            }
        }

      
        private void btnCancel_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        
        private void label1_Click(object sender, EventArgs e) { }
        
    }
}
