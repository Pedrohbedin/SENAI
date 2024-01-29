import { StatusBar } from 'expo-status-bar';
import { useState } from 'react';
import { Image, StyleSheet, Text, TextInput, TouchableOpacity, View } from 'react-native';

export default function App() {
  const [email, setEmail] = useState('')
  const [senha, setSenha] = useState('')
  const onPress = () => {
    setEmail('')
    setSenha('')
  }

  return (
    <View style={styles.container}>
      <View style={styles.loginContainer}>
        <Text style={styles.titleText}>Sing in</Text>
        <View style={styles.inputs}>
          <TextInput style={styles.inputText} keyboardType="email-address" placeholder='Email' placeholderTextColor="black" value={email} onChangeText={setEmail} />
          <TextInput style={styles.inputText} secureTextEntry={true} placeholder='Password' placeholderTextColor="black" value={senha} onChangeText={setSenha} />
        </View>
        <TouchableOpacity style={styles.button}>
          <Text style={styles.text} onPress={() => onPress()}>Login</Text>
        </TouchableOpacity>
      </View>
      <StatusBar style="auto" />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: 'center',
    paddingTop: 75,
    backgroundColor: 'rgb(247, 247, 247)'
  },
  loginContainer: {
    flexDirection: 'column',
    justifyContent: 'center',
    alignItems: 'center',
    gap: 30,
    width: '100%',
    padding: 50
  },
  titleText: {
    fontSize: 50,
    fontWeight: 'bold',
  },
  inputText: {
    borderBottomWidth: 2,
    borderColor: 'black',
    height: 60,
    width: '100%',
    paddingHorizontal: 20,
    fontSize: 20,
    color: 'black'

  },
  inputs: {
    width: '100%',
    gap: 40
  },
  text: {
    color: 'white',
    fontSize: 20
  },
  button: {
    borderWidth: 2,
    backgroundColor: 'black',
    width: '50%',
    padding: 10,
    justifyContent: 'center',
    alignItems: 'center'
  },
  tinyLogo: {
    width: 100,
    height: 100,
  },
  passRecoverView: {
    width: '100%',
    justifyContent: 'end'
  },
  passRecover: {
    color: 'white',
  },
  loginImage: {
    width: 50,
    height: 50
  }
});
