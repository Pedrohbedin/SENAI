import { StatusBar } from 'expo-status-bar';
import { SafeAreaView, FlatList, StyleSheet, View } from 'react-native';
import Person from './src/components/Person/Person';
import Games from './src/components/Games/Games';

export default function App() {
  const peopleList = [
    { id: '1', name: 'Pedro', age: '18' },
    { id: '2', name: 'Silva', age: '25' },
    { id: '3', name: 'Sousa', age: '18' }
  ]

  const Jogos = [
    { id: '1', name: 'Fortnite', price: '17,50' },
    { id: '2', name: 'Euro Truck', price: '25,52' },
    { id: '3', name: 'FIFA 13', price: '100,00' }
  ]
  return (
    <SafeAreaView>
      <View style={styles.divisor}>
        <FlatList
          data={peopleList}
          keyExtractor={(item) => item.id}
          renderItem={({ item }) => <Person name={item.name} age={item.age} />}
        />
        <FlatList
          data={Jogos}
          keyExtractor={(item) => item.id}
          renderItem={({ item }) => <Games name={item.name} price={item.price} />}
        />
      </View>
      {/* <StatusBar/> */}
    </SafeAreaView>
  );

}

const styles = StyleSheet.create({
  divisor: {
    height: '100%',
    justifyContent: 'space-between'
  }
}) 