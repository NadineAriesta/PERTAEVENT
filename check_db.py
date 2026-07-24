import sqlite3

def main():
    conn = sqlite3.connect('eventsupport.db')
    cursor = conn.cursor()
    
    print("=== SUPPORT ACARA ===")
    cursor.execute("SELECT IdAcara, NamaAcara, StatusAcara FROM SupportAcara")
    for row in cursor.fetchall():
        print(row)
        
    print("\n=== MAPPING TEKNISI ===")
    cursor.execute("SELECT IdTeknisi, IdUser, StatusKetersediaan FROM MappingTeknisi")
    for row in cursor.fetchall():
        print(row)
        
    print("\n=== PENUGASAN ===")
    cursor.execute("SELECT IdPenugasan, IdAcara, IdTeknisi, StatusPenugasan FROM Penugasan")
    for row in cursor.fetchall():
        print(row)
        
    conn.close()

if __name__ == '__main__':
    main()
