import { StatusBar } from 'expo-status-bar';
import { useState } from 'react';
import { StyleSheet, View } from 'react-native';
import { Container } from './src/components/container/container';
import { ButtonI } from './src/components/button/button';
import { ButtonD } from './src/components/button/button';
import { Title } from './src/components/title/title';
import { ButtonTitle } from './src/components/title/title';
import { Image } from 'react-native';

export default function App() {
  const [count, setCount] = useState(0);

  // useEffect(() => {
  //   console.warn(count)
  // }, [count])

  return (
    <Container>
      <Image
        style={{width: 100, height: 100}}
        source={{
          uri: 'https://cdn-icons-png.flaticon.com/512/151/151770.png',
        }}
      />
      <Title>{count}</Title>
      <View style={styles.division}>
        <ButtonD onPress={() => count > 0 ? setCount(count - 1) : alert("Deu ruim")}>
          <ButtonTitle>-</ButtonTitle>
        </ButtonD>
        <ButtonI onPress={() => setCount(count + 1)}>
          <ButtonTitle>+</ButtonTitle>
        </ButtonI>
      </View>
      <StatusBar style="auto" />
    </Container>
  );
}

const styles = StyleSheet.create({
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
