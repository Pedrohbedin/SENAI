import { StatusBar } from 'expo-status-bar';
import { useEffect, useState } from 'react';
import { StyleSheet, Text, TextComponent, TouchableOpacity, View } from 'react-native';

export default function App() {
  const [count, setCount] = useState(0);

  // useEffect(() => {
  //   console.warn(count)
  // }, [count])

  return (
    <View style={styles.container}>
      <Text style={styles.countText}>{count}</Text>
      <View style={styles.division}>
        <TouchableOpacity style={styles.btnI} onPress={() => setCount(count + 1)}>
          <Text style={styles.text}>+</Text>
        </TouchableOpacity>
        <TouchableOpacity style={styles.btnD} onPress={() => count > 0 ? setCount(count - 1) : null}>
          <Text style={styles.text}>-</Text>
        </TouchableOpacity>
      </View>
      <StatusBar style="auto" />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: 'black',
    alignItems: 'center',
    justifyContent: 'center',
    height: '100%',
    justifyContent: 'space-around'
  },
  btnI: {
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: 'green',
    width: 100,
    height: 100,
    borderRadius: 10
  },
  btnD: {
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: 'red',
    width: 100,
    height: 100,
    borderRadius: 10
  },
  text: {
    color: 'white',
    fontSize: 50
  },
  division: {
    gap: 30,
    flexDirection: 'row'
  },
  countText: {
    fontSize: 50,
    color: 'white'
  }
});
